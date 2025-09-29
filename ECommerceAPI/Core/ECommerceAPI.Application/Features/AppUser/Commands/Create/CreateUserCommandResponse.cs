using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.AppUser.Commands.Create
{
    public record CreateUserCommandResponse(bool Succeeded, string Message)
    {
    }
}
