using HotelReservationAPI.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Features.Customers.Commands.Create
{
    public record CreateCustomerCommand(string IdentityNumber, string FullName, DateTime DateOfBirth, string PhoneNumber) : IRequest<CreateCustomerCommandResponse>
    {
    }
}
