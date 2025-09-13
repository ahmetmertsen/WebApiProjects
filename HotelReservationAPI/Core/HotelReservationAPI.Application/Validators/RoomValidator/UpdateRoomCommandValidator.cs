using FluentValidation;
using HotelReservationAPI.Application.Features.Rooms.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Validators.RoomValidator
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Oda Id boş olmamalı!")
                .GreaterThan(0).WithMessage("Oda Id 0'dan büyük olmalı!");

            RuleFor(x => x.RoomNo).NotEmpty().WithMessage("Oda numarası boş olmamalı!")
                .GreaterThan(0).WithMessage("Oda numarası 0'dan büyük olmalı!");

            RuleFor(x => x.Capacity).NotEmpty().WithMessage("Oda kapasitesi boş olmamalı!")
                .GreaterThan(0).WithMessage("Oda Kapasitesi 0'dan büyük olmalı");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Oda fiyatı boş olmamalı!")
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalı");
        }
    }
}
