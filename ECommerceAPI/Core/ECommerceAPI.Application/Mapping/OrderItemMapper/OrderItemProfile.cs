using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Mapping.OrderItemMapper
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile() 
        {
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
