using ECommerceAPI.Application.Features.Payments.Commands.UpdatePaymentStatus;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.PaymentValidator
{
    public class UpdatePaymentStatusCommandValidator : AbstractValidator<UpdatePaymentStatusCommand>
    {
        public UpdatePaymentStatusCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("PaymentId boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir PaymentId girilmelidir");
        }
    }
}
