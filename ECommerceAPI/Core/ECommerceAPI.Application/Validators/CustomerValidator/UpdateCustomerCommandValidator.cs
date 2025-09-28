using ECommerceAPI.Application.Features.Customers.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.CustomerValidator
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("CustomerId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir CustomerId girilmelidir");

            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim Soyisim boş olmamalı!")
                .MinimumLength(3).WithMessage("İsim Soyisim en az 3 karekter olmalıdır!");
        }
    }
}
