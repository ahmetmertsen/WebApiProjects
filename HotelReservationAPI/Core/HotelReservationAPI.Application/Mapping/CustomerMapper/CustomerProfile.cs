using AutoMapper;
using HotelReservationAPI.Application.Dtos;
using HotelReservationAPI.Application.Features.Customers.Commands.Create;
using HotelReservationAPI.Application.Features.Customers.Commands.Delete;
using HotelReservationAPI.Application.Features.Customers.Commands.Update;
using HotelReservationAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Mapping.CustomerMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
            
            CreateMap<Customer, CustomerDto>();

            CreateMap<Customer, CreateCustomerCommandResponse>();
            CreateMap<Customer, UpdateCustomerCommandResponse>();
        }
    }
}
