using ECommerceAPI.Application.Features.Orders.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.OrderValidator
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator() 
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir CustomerId girilmelidir");

            RuleFor(x => x.AddressId).NotEmpty().WithMessage("AddressId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir AddressId girilmelidir");
        }
    }
}
