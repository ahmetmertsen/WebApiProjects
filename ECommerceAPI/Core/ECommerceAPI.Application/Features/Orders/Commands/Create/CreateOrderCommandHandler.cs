using AutoMapper;
using ECommerceAPI.Application.Features.Orders.Queries.GetAll;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Enum;
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

            var cart = await _unitOfWork.CartRepository.GetByUserIdAsync(request.UserId);

            var cartItem = await _unitOfWork.CartItemRepository.GetAllByCartIdAsync(cart.Id);
            if (cartItem == null)
            {
                //Exception yazılacak.
            }

            var order = new Order { UserId = request.UserId , AddressId=request.AddressId, Status = OrderStatus.Pending, TotalAmount = 0, Items = new List<OrderItem>() };

            foreach (var item in cartItem)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                {
                    //Exception Yazılacak.
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

            return new CreateOrderCommandResponse(order.Id, order.UserId, order.AddressId, order.Status);
        }
    }
}
