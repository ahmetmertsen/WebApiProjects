using FluentValidation;
using HotelReservationAPI.Application.Features.Customers.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Validators.CustomerValidator
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator() 
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim Soyisim boş olmamalı!")
                .MinimumLength(3).WithMessage("İsim Soyisim en az 3 karekter olmalıdır!");
            
            RuleFor(x => x.IdentityNumber).NotEmpty().WithMessage("TC Kimlik Numarası boş olmamalı!")
                .Length(11).WithMessage("Tc Kimlik Numarası 11 karakter olmalı!");

            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Doğum Tarihi boş olmamalıdır.")
                .LessThan(DateTime.Today).WithMessage("Doğum Tarihi bugünden küçük olmalıdır!");

            RuleFor(x => x.PhoneNumber).Matches(@"^\+?\d{10,15}$").WithMessage("Geçersiz telefon numarası");
        }
    }
}
