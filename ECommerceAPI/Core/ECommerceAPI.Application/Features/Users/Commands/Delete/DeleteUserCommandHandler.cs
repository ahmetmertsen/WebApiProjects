using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,DeleteUserCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<DeleteUserCommand> _validator;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteUserCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request,cancellationToken);

            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException($"{request.Id} Id'sine ait Kullanıcı bulunamadı...");
            }

            await _unitOfWork.UserRepository.RemoveAsync(user.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new DeleteUserCommandResponse(user.Id);
        }
    }
}
