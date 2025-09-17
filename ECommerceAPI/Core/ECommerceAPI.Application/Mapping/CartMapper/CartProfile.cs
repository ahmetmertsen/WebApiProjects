using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Features.Carts.Commands.Create;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Mapping.CartMapper
{
    public class CartProfile : Profile
    {
        public CartProfile() 
        {
            CreateMap<CreateCartCommand, Cart>();

            CreateMap<Cart, CartDto>();

            CreateMap<Cart, CreateCartCommandResponse>();
        }
    }
}
