﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.AppUser.Commands.Create
{
    public record CreateUserCommand(string FullName, string Email, string Password, string PhoneNumber) : IRequest<CreateUserCommandResponse>
    {
    }
}
