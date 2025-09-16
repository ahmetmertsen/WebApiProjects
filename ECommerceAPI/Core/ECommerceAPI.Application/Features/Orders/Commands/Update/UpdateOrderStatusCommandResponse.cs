using ECommerceAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Orders.Commands.Update
{
    public record UpdateOrderStatusCommandResponse(int Id,OrderStatus OrderStatus)
    {
    }
}
