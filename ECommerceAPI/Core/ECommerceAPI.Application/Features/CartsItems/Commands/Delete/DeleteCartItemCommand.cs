using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.CartsItems.Commands.Delete
{
    public record DeleteCartItemCommand(int Id) : IRequest<DeleteCartItemCommandResponse>
    {
    }
}
