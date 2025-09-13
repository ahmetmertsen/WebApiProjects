using FluentValidation;
using HotelReservationAPI.Application.Features.Customers.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Validators.CustomerValidator
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("CustomerId boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir CustomerId girilmelidir");

            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim Soyisim boş olmamalı!")
                .MinimumLength(3).WithMessage("İsim Soyisim en az 3 karekter olmalıdır!");
            
            RuleFor(x => x.IdentityNumber).NotEmpty().WithMessage("TC Kimlik Numarası boş olmamalı!")
            .Length(11).WithMessage("Tc Kimlik Numarası 11 karakter olmalı!");

            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Doğum Tarihi boş olmamalıdır.")
                .LessThan(DateTime.Today).WithMessage("Doğum Tarihi bugünden küçük olmamalı!");

            RuleFor(x => x.PhoneNumber).Matches(@"^\+?\d{10,15}$").WithMessage("Geçersiz telefon numarası");
        }
    }
}
