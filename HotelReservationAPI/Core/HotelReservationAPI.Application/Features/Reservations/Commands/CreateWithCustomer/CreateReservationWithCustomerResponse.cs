using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Reservations.Commands.CreateWithCustomer
{
    public record CreateReservationWithCustomerResponse(int Id, int CustomerId, int RoomId, DateTime StartDate, DateTime EndDate)
    {
    }
}
