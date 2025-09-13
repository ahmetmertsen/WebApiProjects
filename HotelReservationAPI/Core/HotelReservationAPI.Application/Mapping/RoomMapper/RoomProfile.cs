using AutoMapper;
using HotelReservationAPI.Application.Dtos;
using HotelReservationAPI.Application.Features.Customers.Commands.Delete;
using HotelReservationAPI.Application.Features.Rooms.Commands.Create;
using HotelReservationAPI.Application.Features.Rooms.Commands.Delete;
using HotelReservationAPI.Application.Features.Rooms.Commands.Update;
using HotelReservationAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Mapping.RoomMapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile() 
        {
            CreateMap<CreateRoomCommand, Room>();
            CreateMap<UpdateRoomCommand, Room>();

            CreateMap<Room, RoomDto>();

            CreateMap<Room, CreateRoomCommandResponse>();
            CreateMap<Room, UpdateRoomCommandResponse>();
        }
    }
}
