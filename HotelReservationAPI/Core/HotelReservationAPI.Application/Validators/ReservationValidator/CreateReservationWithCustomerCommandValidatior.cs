using FluentValidation;
using HotelReservationAPI.Application.Features.Reservations.Commands.CreateWithCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Validators.ReservationValidator
{
    public class CreateReservationWithCustomerCommandValidator
        : AbstractValidator<CreateReservationWithCustomerCommand>
    {
        public CreateReservationWithCustomerCommandValidator()
        {
            RuleFor(x => x.IdentityNumber)
                .NotEmpty().Length(11).WithMessage("TC Kimlik numarası 11 karakter olmalı!");

            RuleFor(x => x.FullName)
                .NotEmpty().MinimumLength(3);

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.UtcNow).WithMessage("Doğum tarihi bugünden küçük olmalı!");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?\d{10,15}$").WithMessage("Telefon numarası geçersiz!");

            RuleFor(x => x.RoomId)
                .GreaterThan(0).WithMessage("Geçerli bir oda seçilmelidir!");

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate).WithMessage("Başlangıç tarihi bitiş tarihinden küçük olmalı.");
        }
    }
}