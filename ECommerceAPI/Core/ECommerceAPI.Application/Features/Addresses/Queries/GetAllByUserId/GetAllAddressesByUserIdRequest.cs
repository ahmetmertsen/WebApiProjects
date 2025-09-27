using ECommerceAPI.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Addresses.Queries.GetAllByUserId
{
    public record GetAllAddressesByUserIdRequest(int  userId) : IRequest<List<AddressDto>>
    {
    }
}
