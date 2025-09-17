using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Features.CartsItems.Commands.Create;
using ECommerceAPI.Application.Features.CartsItems.Commands.Update;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Mapping.CartItemMapper
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile() 
        {
            CreateMap<CreateCartItemCommand, CartItem>();
            CreateMap<UpdateCartItemCommand, CartItem>();

            CreateMap<CartItem, CartItemDto>();

            CreateMap<CartItem, CreateCartItemCommandResponse>();
            CreateMap<CartItem,  UpdateCartItemCommandResponse>();
        }
    }
}
