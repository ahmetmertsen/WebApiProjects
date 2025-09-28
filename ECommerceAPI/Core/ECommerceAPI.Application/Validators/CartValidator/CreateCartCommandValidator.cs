using ECommerceAPI.Application.Features.Carts.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.CartValidator
{
    public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidator() 
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir CustomerId girilmelidir");
        }
    }
}
