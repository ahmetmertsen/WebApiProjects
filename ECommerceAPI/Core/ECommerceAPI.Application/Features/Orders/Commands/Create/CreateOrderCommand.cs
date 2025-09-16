using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Orders.Commands.Create
{
    public record CreateOrderCommand(int UserId, int AddressId) : IRequest<CreateOrderCommandResponse>
    {
    }
}
