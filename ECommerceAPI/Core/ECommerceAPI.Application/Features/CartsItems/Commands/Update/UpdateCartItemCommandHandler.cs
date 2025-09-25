using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.CartsItems.Commands.Update
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand,UpdateCartItemCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateCartItemCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateCartItemCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateCartItemCommand> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UpdateCartItemCommandResponse> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            var CartItemEntity = await _unitOfWork.CartItemRepository.GetByIdAsync(request.Id);
            if (CartItemEntity == null)
            {
                //Exception yazılacak.
            }

            _mapper.Map(request, CartItemEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var cartItemDto = _mapper.Map<CartItemDto>(CartItemEntity);
            return new UpdateCartItemCommandResponse(cartItemDto);

        }
    }
}
