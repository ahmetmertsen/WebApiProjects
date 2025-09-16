using ECommerceAPI.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Users.Commands.Create
{
    public record CreateUserCommand(string FullName, string Email, string Password, UserRole UserRole, string PhoneNumber) : IRequest<CreateUserCommandResponse>
    {
    }
}
