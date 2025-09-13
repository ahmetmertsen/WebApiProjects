using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Reservations.Commands.Create
{
    public record CreateReservationCommand(int CustomerId, int RoomId, DateTime StartDate, DateTime EndDate) : IRequest<CreateReservationCommandResponse>
    {
    }
}
