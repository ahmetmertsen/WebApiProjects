using ECommerceAPI.Application.Features.Customers.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.CustomerValidator
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator() 
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim Soyisim boş olmamalı!")
                .MinimumLength(3).WithMessage("İsim Soyisim en az 3 karekter olmalıdır!");
        }
    }
}
