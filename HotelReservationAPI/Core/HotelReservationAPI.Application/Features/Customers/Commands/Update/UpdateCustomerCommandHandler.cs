using AutoMapper;
using FluentValidation;
using HotelReservationAPI.Application.Features.Customers.Commands.Create;
using HotelReservationAPI.Application.UnitOfWork;
using HotelReservationAPI.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateCustomerCommand> _validator;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateCustomerCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var customerEntity = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            if (customerEntity == null) {
                throw new NotFoundException("Müşteri Bulunamadı...");
            }
            _mapper.Map(request, customerEntity);
            customerEntity.DateOfBirth = DateTime.SpecifyKind(request.DateOfBirth, DateTimeKind.Utc);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new UpdateCustomerCommandResponse(customerEntity.Id, customerEntity.IdentityNumber, customerEntity.FullName, customerEntity.DateOfBirth, customerEntity.PhoneNumber);
        }
    }
}
