using ECommerceAPI.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Customers.Commands.Update
{
    public record UpdateCustomerCommand(int Id, string FullName) : IRequest<UpdateCustomerCommandResponse>
    {
    }
}
