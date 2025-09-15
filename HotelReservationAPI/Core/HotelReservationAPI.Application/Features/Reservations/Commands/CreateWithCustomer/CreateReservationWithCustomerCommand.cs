using HotelReservationAPI.Application.Features.Reservations.Commands.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Reservations.Commands.CreateWithCustomer
{
    public record CreateReservationWithCustomerCommand(string IdentityNumber, string FullName, DateTime DateOfBirth, string PhoneNumber, int RoomId, DateTime StartDate, DateTime EndDate)
        : IRequest<CreateReservationWithCustomerResponse>
    {
    }
}
