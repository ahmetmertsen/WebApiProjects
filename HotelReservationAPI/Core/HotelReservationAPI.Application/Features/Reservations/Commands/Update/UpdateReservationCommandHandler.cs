using AutoMapper;
using FluentValidation;
using HotelReservationAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Reservations.Commands.Update
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, UpdateReservationCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateReservationCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateReservationCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateReservationCommand> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UpdateReservationCommandResponse> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var reservationEntity = await _unitOfWork.ReservationRepository.GetByIdAsync(request.Id);
            if (reservationEntity == null)
            {
                //Exception yazılacak
            }
            
            _mapper.Map(request, reservationEntity);
            reservationEntity.StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
            reservationEntity.EndDate = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new UpdateReservationCommandResponse(reservationEntity.Id, reservationEntity.CustomerId, reservationEntity.RoomId, reservationEntity.StartDate, reservationEntity.EndDate);

        }
    }
}
