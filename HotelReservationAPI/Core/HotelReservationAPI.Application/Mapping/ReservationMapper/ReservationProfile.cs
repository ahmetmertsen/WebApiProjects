using AutoMapper;
using HotelReservationAPI.Application.Dtos;
using HotelReservationAPI.Application.Features.Reservations.Commands.Create;
using HotelReservationAPI.Application.Features.Reservations.Commands.Update;
using HotelReservationAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Mapping.ReservationMapper
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile() 
        {
            CreateMap<CreateReservationCommand, Reservation>();
            CreateMap<UpdateReservationCommand, Reservation>();

            CreateMap<Reservation, ReservationDto>();

            CreateMap<Reservation, CreateReservationCommandResponse>();
            CreateMap<Reservation, UpdateReservationCommandResponse>();
        }
    }
}
