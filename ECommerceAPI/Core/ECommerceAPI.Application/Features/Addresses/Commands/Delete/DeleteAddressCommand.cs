using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Addresses.Commands.Delete
{
    public record DeleteAddressCommand(int Id) : IRequest<DeleteAddressCommandResponse>
    {
    }
}
