using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.CartsItems.Commands.Update
{
    public record UpdateCartItemCommand(int Id, int Piece) : IRequest<UpdateCartItemCommandResponse>
    {
    }
}
