using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Application.Dtos;

namespace UserManagementAPI.Application.Features.Users.Queries.GetAll
{
    public record GetAllUsersRequest : IRequest<List<UserDto>>
    {
    }
}
