using ECommerceAPI.Application.Features.Orders.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.OrderValidator
{
    public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("OrderId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir OrderId girilmelidir");
        }
    }
}
