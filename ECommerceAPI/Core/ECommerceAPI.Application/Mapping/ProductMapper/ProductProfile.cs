using AutoMapper;
using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Features.Products.Commands.Create;
using ECommerceAPI.Application.Features.Products.Commands.Update;
using ECommerceAPI.Application.Features.Products.Commands.UpdateStock;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Mapping.ProductMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<UpdateProductStockCommand, Product>();

            CreateMap<Product, ProductDto>();

            CreateMap<Product, CreateProductCommandResponse>();
            CreateMap<Product, UpdateProductCommandResponse>();
            CreateMap<Product, UpdateProductStockCommandResponse>();
        }
    }
}
