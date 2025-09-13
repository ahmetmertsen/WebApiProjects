using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Customers.Commands.Create
{
    public record CreateCustomerCommandResponse(int Id,string IdentityNumber, string FullName, DateTime DateOfBirth, string PhoneNumber)
    {
    }
}
