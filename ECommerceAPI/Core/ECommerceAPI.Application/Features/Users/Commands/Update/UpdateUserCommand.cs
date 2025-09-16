using ECommerceAPI.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Users.Commands.Update
{
    public record UpdateUserCommand(int Id, string FullName, string Email ,string Password, UserRole UserRole, string PhoneNumber) : IRequest<UpdateUserCommandResponse>
    {
    }
}
