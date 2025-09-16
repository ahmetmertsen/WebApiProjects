using ECommerceAPI.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Products.Queries.GetById
{
    public record GetByIdProductRequest(int Id) : IRequest<ProductDto>
    {
    }
}
