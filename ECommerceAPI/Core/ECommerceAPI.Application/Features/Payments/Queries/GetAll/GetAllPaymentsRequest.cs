using ECommerceAPI.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Payments.Queries.GetAll
{
    public record GetAllPaymentsRequest() : IRequest<List<PaymentDto>>
    {
    }
}
