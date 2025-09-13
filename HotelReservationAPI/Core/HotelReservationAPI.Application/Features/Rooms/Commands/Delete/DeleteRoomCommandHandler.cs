using FluentValidation;
using HotelReservationAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Rooms.Commands.Delete
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, DeleteRoomCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<DeleteRoomCommand> _validator;

        public DeleteRoomCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteRoomCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;

        }

        public async Task<DeleteRoomCommandResponse> Handle(DeleteRoomCommand request,  CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            await _unitOfWork.RoomRepository.RemoveAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new DeleteRoomCommandResponse(request.Id);
        }
    }
}
