using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Products.Commands.Create
{
    public record CreateProductCommand(string Name, decimal Price, int Stock) : IRequest<CreateProductCommandResponse>
    {
    }
}
