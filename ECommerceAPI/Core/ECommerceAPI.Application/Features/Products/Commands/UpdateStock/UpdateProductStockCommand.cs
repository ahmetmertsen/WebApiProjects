using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Products.Commands.UpdateStock
{
    public record UpdateProductStockCommand(int Id) : IRequest<UpdateProductStockCommandResponse>
    {
    }
}
