using ECommerceAPI.Application.Features.Customers.Commands.Delete;
using ECommerceAPI.Application.UnitOfWork;
using ECommerceAPI.Domain.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<DeleteCustomerCommand> _validator;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteCustomerCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                throw new NotFoundException($"{request.Id} Id'sine ait Müşteri bulunamadı...");
            }

            await _unitOfWork.CustomerRepository.RemoveAsync(customer.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new DeleteCustomerCommandResponse(customer.Id);
        }
    }
}
