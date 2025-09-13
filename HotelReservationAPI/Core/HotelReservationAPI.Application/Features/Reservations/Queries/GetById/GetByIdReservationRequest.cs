using HotelReservationAPI.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Reservations.Queries.GetById
{
    public record GetByIdReservationRequest(int Id) : IRequest<ReservationDto>
    {
    }
}
