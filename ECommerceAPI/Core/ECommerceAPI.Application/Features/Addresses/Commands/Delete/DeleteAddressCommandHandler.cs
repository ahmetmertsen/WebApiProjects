using ECommerceAPI.Application.UnitOfWork;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Addresses.Commands.Delete
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand,DeleteAddressCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<DeleteAddressCommand> _validator;

        public DeleteAddressCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteAddressCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            await _unitOfWork.AddressRepository.RemoveAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteAddressCommandResponse(request.Id);
        }
    }
}
