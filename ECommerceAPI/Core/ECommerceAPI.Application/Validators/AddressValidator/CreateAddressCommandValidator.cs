using ECommerceAPI.Application.Features.Addresses.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.AddressValidator
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator() 
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir UserId girilmelidir");

            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir boş olmamalı!");

            RuleFor(x => x.District).NotEmpty().WithMessage("İlçe boş olmamalı!");

            RuleFor(x => x.AddressDetails).NotEmpty().WithMessage("Adres detayı boş olmamalı!");

        }
    }
}
