using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Products.Commands.Update
{
    public record UpdateProductCommand(int Id, string Name, decimal Price, int Stock) : IRequest<UpdateProductCommandResponse>
    {
    }
}
