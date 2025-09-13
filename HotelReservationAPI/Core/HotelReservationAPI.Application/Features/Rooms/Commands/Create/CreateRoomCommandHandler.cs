using AutoMapper;
using FluentValidation;
using HotelReservationAPI.Application.UnitOfWork;
using HotelReservationAPI.Application.Validators.RoomValidator;
using HotelReservationAPI.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Rooms.Commands.Create
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, CreateRoomCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateRoomCommand> _validator;

        public CreateRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateRoomCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateRoomCommandResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var roomEntity = _mapper.Map<Room>(request);
            await _unitOfWork.RoomRepository.AddAsync(roomEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new CreateRoomCommandResponse(roomEntity.Id, roomEntity.RoomNo, roomEntity.Capacity, roomEntity.Price);
        }
    }
}
