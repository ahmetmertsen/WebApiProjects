using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Addresses.Commands.Create
{
    public record CreateAddressCommand(int UserId, string City, string District, string AddressDetails) : IRequest<CreateAddressCommandResponse>
    {
    }
}
