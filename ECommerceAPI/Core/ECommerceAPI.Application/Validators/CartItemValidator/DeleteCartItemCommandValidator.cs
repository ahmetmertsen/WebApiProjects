using ECommerceAPI.Application.Features.CartsItems.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.CartItemValidator
{
    public class DeleteCartItemCommandValidator : AbstractValidator<DeleteCartItemCommand>
    {
        public DeleteCartItemCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("CartItemId boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir CartItemId girilmelidir");
        }
    }
}
