using ECommerceAPI.Application.Features.Addresses.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.AddressValidator
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir Id girilmelidir");

            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir boş olmamalı!");

            RuleFor(x => x.District).NotEmpty().WithMessage("İlçe boş olmamalı!");

            RuleFor(x => x.AddressDetails).NotEmpty().WithMessage("Adres detayı boş olmamalı!");
        }
    }
}
