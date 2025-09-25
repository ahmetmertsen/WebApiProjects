using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.CartsItems.Commands.Delete
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand,DeleteCartItemCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<DeleteCartItemCommand> _validator;
        
        public DeleteCartItemCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteCartItemCommand> validator) 
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<DeleteCartItemCommandResponse> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            var cartItem = await _unitOfWork.CartItemRepository.GetByIdAsync(request.Id);
            if (cartItem == null)
            {
                throw new NotFoundException($"{request.Id} Id'sine ait Sepet İçeriği bulunamadı...");
            }

            await _unitOfWork.CartItemRepository.RemoveAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteCartItemCommandResponse(request.Id);
        }
    }
}
