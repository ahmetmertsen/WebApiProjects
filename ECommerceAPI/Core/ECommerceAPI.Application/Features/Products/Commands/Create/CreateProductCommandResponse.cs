using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Products.Commands.Create
{
    public record CreateProductCommandResponse(int Id, string Name, decimal Price ,int Stock)
    {
    }
}
