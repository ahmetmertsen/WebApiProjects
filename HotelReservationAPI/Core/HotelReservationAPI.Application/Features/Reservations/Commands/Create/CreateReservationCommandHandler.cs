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

namespace HotelReservationAPI.Application.Features.Reservations.Commands.Create
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, CreateReservationCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateReservationCommand> _validator;

        public CreateReservationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateReservationCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateReservationCommandResponse> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var reservationEntity = _mapper.Map<Reservation>(request);
            reservationEntity.StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
            reservationEntity.EndDate = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc);

            await _unitOfWork.ReservationRepository.AddAsync(reservationEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new CreateReservationCommandResponse(reservationEntity.Id, reservationEntity.CustomerId, reservationEntity.RoomId, reservationEntity.StartDate, reservationEntity.EndDate);
        }
    }
}
