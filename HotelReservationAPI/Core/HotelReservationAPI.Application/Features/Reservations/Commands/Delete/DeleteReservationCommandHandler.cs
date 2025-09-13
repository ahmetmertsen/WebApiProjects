using FluentValidation;
using HotelReservationAPI.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Reservations.Commands.Delete
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, DeleteReservationCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<DeleteReservationCommand> _validator;

        public DeleteReservationCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteReservationCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<DeleteReservationCommandResponse> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            await _unitOfWork.ReservationRepository.RemoveAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new DeleteReservationCommandResponse(request.Id);
        }
    }
}
