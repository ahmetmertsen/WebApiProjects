using ECommerceAPI.Application.Features.Users.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.UserValidator
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("UserId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir UserId girilmelidir");

            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim Soyisim boş olmamalı!")
                .MinimumLength(3).WithMessage("İsim Soyisim en az 3 karekter olmalıdır!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş olmamalı!").EmailAddress();

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olmamalı!")
                .MinimumLength(4).WithMessage("Şifre en az 4 karekter olmalıdır!");

            RuleFor(x => x.PhoneNumber).Matches(@"^\+?\d{10,15}$").WithMessage("Geçersiz telefon numarası!");
        }
    }
}
