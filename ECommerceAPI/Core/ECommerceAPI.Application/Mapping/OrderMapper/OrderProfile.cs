using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Features.Orders.Commands.Create;
using ECommerceAPI.Application.Features.Orders.Commands.Update;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Mapping.OrderMapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderStatusCommand, Order>();

            CreateMap<Order, OrderDto>();

            CreateMap<Order, CreateOrderCommandResponse>();
            CreateMap<Order, UpdateOrderStatusCommandResponse>();
        }
    }
}
