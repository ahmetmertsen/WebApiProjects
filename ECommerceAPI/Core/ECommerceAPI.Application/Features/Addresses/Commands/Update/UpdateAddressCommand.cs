using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Addresses.Commands.Update
{
    public record UpdateAddressCommand(int Id, string City, string District, string AddressDetails) : IRequest<UpdateAddressCommandResponse>
    {

    }
}
