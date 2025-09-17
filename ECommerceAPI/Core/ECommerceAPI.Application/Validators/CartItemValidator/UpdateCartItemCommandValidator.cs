using ECommerceAPI.Application.Features.CartsItems.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.CartItemValidator
{
    public class UpdateCartItemCommandValidator : AbstractValidator<UpdateCartItemCommand>
    {
        public UpdateCartItemCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("CartItemId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir CarItemtId girilmelidir");

            RuleFor(x => x.Piece).NotEmpty().WithMessage("Adet boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir adet sayısı girilmelidir");
        }
    }
}
