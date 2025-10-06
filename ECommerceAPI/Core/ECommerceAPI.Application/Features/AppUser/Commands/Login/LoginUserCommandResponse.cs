using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.AppUser.Commands.Login
{
    public record LoginUserCommandResponse(bool Succeeded, string Message)
    {
    }
}
