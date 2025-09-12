using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementAPI.Application.Features.Users.Commands.Create
{
    public record CreateUserCommand(string FirstName, string LastName , string Email, string Address) : IRequest<bool>
    {
    }
}
