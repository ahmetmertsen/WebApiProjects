using AutoMapper;
using ECommerceAPI.Application.Features.Orders.Queries.GetAll;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Enum;
using ECommerceAPI.Domain.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Orders.Commands.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand,CreateOrderCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateOrderCommand> _validator;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateOrderCommand> validator, IMapper mapper   )
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var cart = await _unitOfWork.CartRepository.GetByCustomerIdAsync(request.CustomerId);
            if (cart == null)
            {
                throw new NotFoundException($"{request.CustomerId} Id'sine ait Müşteri Sepeti bulunamadı...");
            }

            var cartItem = await _unitOfWork.CartItemRepository.GetAllByCartIdAsync(cart.Id);
            if (cartItem == null)
            {
                throw new NotFoundException($"{cart.Id} Id'sine ait Sepet bulunamadı...");
            }

            var order = new Order { CustomerId = request.CustomerId, AddressId=request.AddressId, Status = OrderStatus.Pending, TotalAmount = 0, Items = new List<OrderItem>() };

            foreach (var item in cartItem)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                {
                    throw new NotFoundException($"{item.ProductId} Id'sine ait Ürün bulunamadı...");
                }

                var orderItem = new OrderItem { ProductId = item.ProductId, Piece = item.Piece, UnitPrice = product.Price };
                order.TotalAmount += orderItem.UnitPrice * orderItem.Piece;
                order.Items.Add(orderItem);

                product.Stock -= item.Piece;
                _unitOfWork.ProductRepository.Update(product);
            }

            await _unitOfWork.OrderRepository.AddAsync(order);

            foreach (var item2 in cart.Items.ToList())
            {
                await _unitOfWork.CartItemRepository.RemoveAsync(item2.Id);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateOrderCommandResponse(order.Id, order.CustomerId, order.AddressId, order.Status);
        }
    }
}
