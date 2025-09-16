using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.CartsItems.Commands.Create
{
    public record CreateCartItemCommand(int CartId, int ProductId, int Piece) : IRequest<CreateCartItemCommandResponse>
    {
    }
}
