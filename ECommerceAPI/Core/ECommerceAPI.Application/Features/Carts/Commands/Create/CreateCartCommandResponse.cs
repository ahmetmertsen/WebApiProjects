using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Carts.Commands.Create
{
    public record CreateCartCommandResponse(int Id, int CustomerId)
    {
    }
}
