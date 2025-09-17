using ECommerceAPI.Application.Features.Payments.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.PaymentValidator
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir OrderId girilmelidir");

            RuleFor(x => x.Amount).NotEmpty().WithMessage("Tutar boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir tutar girilmelidir");
        }
    }
}
