using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Rooms.Commands.Create
{
    public record CreateRoomCommandResponse(int Id, long RoomNo, int Capacity, long Price)
    {
    }
}
