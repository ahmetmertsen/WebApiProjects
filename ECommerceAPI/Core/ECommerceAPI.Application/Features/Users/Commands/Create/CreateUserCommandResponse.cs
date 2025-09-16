using ECommerceAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Users.Commands.Create
{
    public record CreateUserCommandResponse(int Id, string FullName, string Email, UserRole UserRole)
    {
    }
}
