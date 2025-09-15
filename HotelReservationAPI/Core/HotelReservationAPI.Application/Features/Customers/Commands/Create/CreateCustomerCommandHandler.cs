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

namespace HotelReservationAPI.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCustomerCommand> _validator;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCustomerCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var customerEntity = _mapper.Map<Customer>(request);
            customerEntity.DateOfBirth = DateTime.SpecifyKind(request.DateOfBirth, DateTimeKind.Utc);

            await _unitOfWork.CustomerRepository.AddAsync(customerEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new CreateCustomerCommandResponse(customerEntity.Id, customerEntity.IdentityNumber, customerEntity.FullName, customerEntity.DateOfBirth, customerEntity.PhoneNumber);
        }
    }
}
