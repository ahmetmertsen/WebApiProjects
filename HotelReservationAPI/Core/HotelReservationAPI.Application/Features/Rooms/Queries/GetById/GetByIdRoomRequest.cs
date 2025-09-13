using HotelReservationAPI.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Rooms.Queries.GetById
{
    public record GetByIdRoomRequest(int Id) : IRequest<RoomDto>
    {
    }
}
