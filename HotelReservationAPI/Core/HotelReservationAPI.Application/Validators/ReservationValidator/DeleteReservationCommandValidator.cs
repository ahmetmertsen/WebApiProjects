using FluentValidation;
using HotelReservationAPI.Application.Features.Reservations.Commands.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Validators.ReservationValidator
{
    public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
    {
        public DeleteReservationCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Rezervasyon Id boş olmamalı!")
            .GreaterThan(0).WithMessage("Geçerli bir Rezerasyon girilmelidir");
        }
    }
}
