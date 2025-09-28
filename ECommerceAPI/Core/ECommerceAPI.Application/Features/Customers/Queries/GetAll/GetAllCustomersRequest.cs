using ECommerceAPI.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Customers.Queries.GetAll
{
    public record GetAllCustomersRequest : IRequest<List<CustomerDto>>
    {
    }
}
