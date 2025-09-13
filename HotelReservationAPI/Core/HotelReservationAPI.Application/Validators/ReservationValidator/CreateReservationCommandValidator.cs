using FluentValidation;
using HotelReservationAPI.Application.Features.Reservations.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Validators.ReservationValidator
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator() 
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir CustomerId girilmeli!");

            RuleFor(x => x.RoomId).NotEmpty().WithMessage("RoomId boş olmamalı!")
                .GreaterThan(0).WithMessage("Geçerli bir RoomId girilmeli!");

            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Giriş Tarihi boş olmamalı!")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Giriş Tarihi bugünden küçük olmamalı!");

            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Çıkış Tarihi boş olmamalı!")
                .GreaterThan(x => x.StartDate).WithMessage("Çıkış Tarihi giriş tarihinden küçük olmamalı!");
        }
    }
}
