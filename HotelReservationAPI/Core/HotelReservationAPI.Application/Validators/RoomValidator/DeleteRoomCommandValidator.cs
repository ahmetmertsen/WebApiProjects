using FluentValidation;
using HotelReservationAPI.Application.Features.Rooms.Commands.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Validators.RoomValidator
{
    public class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Oda Id boş olmamalı!")
                .GreaterThan(0).WithMessage("Oda Id 0'dan büyük olmalı!");
        }
    }
}
