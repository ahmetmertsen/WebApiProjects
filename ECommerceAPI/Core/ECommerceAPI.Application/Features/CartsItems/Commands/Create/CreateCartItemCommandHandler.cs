using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.CartsItems.Commands.Create
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand,CreateCartItemCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateCartItemCommand> _validator;
        private readonly IMapper _mapper;

        public CreateCartItemCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateCartItemCommand> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<CreateCartItemCommandResponse> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            var cartEntity = await _unitOfWork.CartRepository.GetByIdAsync(request.CartId);
            if (cartEntity == null)
            {
                throw new NotFoundException($"{request.CartId} Id'sine ait Sepet bulunamadı...");
            }

            var productEntity = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
            if (productEntity == null) 
            {
                throw new NotFoundException($"{request.ProductId} Id'sine ait Ürün bulunamadı...");
            }

            var cartItemEntity = _mapper.Map<CartItem>(request);
            await _unitOfWork.CartItemRepository.AddAsync(cartItemEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<CartItemDto>(cartItemEntity);
            return new CreateCartItemCommandResponse(response);
        }
    }
}
