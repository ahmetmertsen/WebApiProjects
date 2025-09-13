using AutoMapper;
using FluentValidation;
using HotelReservationAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Rooms.Commands.Update
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, UpdateRoomCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateRoomCommand> _validator;

        public UpdateRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateRoomCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateRoomCommandResponse> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var roomEntity = await _unitOfWork.RoomRepository.GetByIdAsync(request.Id);
            if (roomEntity == null)
            {
                //Exception yazılacak.
            }

            _mapper.Map(request, roomEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new UpdateRoomCommandResponse(roomEntity.Id, roomEntity.RoomNo, roomEntity.Capacity, roomEntity.Price);
        }
    }
}
