using ECommerceAPI.Application.Features.CartsItems.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.CartItemValidator
{
    public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
    {
        public CreateCartItemCommandValidator() 
        {
            RuleFor(x => x.CartId).NotEmpty().WithMessage("CartId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir CartId girilmelidir");

            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir ProductId girilmelidir");

            RuleFor(x => x.Piece).NotEmpty().WithMessage("Adet boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir adet sayısı girilmelidir");
        }
    }
}
