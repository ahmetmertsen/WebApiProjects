using AutoMapper;
using FluentValidation;
using HotelReservationAPI.Application.Features.Reservations.Commands.Create;
using HotelReservationAPI.Application.UnitOfWork;
using HotelReservationAPI.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Reservations.Commands.CreateWithCustomer
{
    public class CreateReservationWithCustomerCommandHandler : IRequestHandler<CreateReservationWithCustomerCommand, CreateReservationWithCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateReservationWithCustomerCommand> _validator;

        public CreateReservationWithCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateReservationWithCustomerCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateReservationWithCustomerResponse> Handle(CreateReservationWithCustomerCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var customer = await _unitOfWork.CustomerRepository.GetByIdentityNumberAsync(request.IdentityNumber);
            if (customer == null)
            {
                customer = _mapper.Map<Customer>(request);
                customer.DateOfBirth = DateTime.SpecifyKind(request.DateOfBirth, DateTimeKind.Utc);
                await _unitOfWork.CustomerRepository.AddAsync(customer);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            var reservationEntity = _mapper.Map<Reservation>(request);
            reservationEntity.CustomerId = customer.Id;
            reservationEntity.StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
            reservationEntity.EndDate = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc);

            await _unitOfWork.ReservationRepository.AddAsync(reservationEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new CreateReservationWithCustomerResponse(reservationEntity.Id, customer.Id, reservationEntity.RoomId, reservationEntity.StartDate, reservationEntity.EndDate);
            
        }
    }
}
