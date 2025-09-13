using AutoMapper;
using FluentValidation;
using HotelReservationAPI.Application.UnitOfWork;
using HotelReservationAPI.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Customers.Commands.Delete
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
            await _unitOfWork.CustomerRepository.RemoveAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new DeleteCustomerCommandResponse(request.Id);
        }
    }
}
