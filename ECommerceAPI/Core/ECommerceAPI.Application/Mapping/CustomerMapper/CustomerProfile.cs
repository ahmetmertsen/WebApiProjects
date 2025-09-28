using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Features.Customers.Commands.Create;
using ECommerceAPI.Application.Features.Customers.Commands.Update;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Mapping.CustomerMapper
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
