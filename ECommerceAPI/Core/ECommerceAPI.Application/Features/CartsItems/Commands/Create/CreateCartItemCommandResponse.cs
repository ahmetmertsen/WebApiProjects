using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.CartsItems.Commands.Create
{
    public record CreateCartItemCommandResponse(int Id, int CartId, int ProductId, int Piece, bool isCreated)
    {
    }
}
