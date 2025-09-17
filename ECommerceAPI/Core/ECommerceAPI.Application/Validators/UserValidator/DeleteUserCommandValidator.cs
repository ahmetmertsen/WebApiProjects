using ECommerceAPI.Application.Features.Users.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.UserValidator
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("UserId boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir UserId girilmelidir");
        }
    }
}
