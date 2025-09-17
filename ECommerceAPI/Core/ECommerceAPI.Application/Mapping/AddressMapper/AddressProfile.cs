using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Features.Addresses.Commands.Create;
using ECommerceAPI.Application.Features.Addresses.Commands.Update;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Mapping.AddressMapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile() 
        {
            CreateMap<CreateAddressCommand, Address>();
            CreateMap<UpdateAddressCommand, Address>();

            CreateMap<Address, AddressDto>();

            CreateMap<Address, CreateAddressCommandResponse>();
            CreateMap<Address, UpdateAddressCommandResponse>();
        }
    }
}
