using ECommerceAPI.Application.Features.Customers.Commands.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Customers.Commands.Create
{
    public record CreateCustomerCommand(string FullName) : IRequest<CreateCustomerCommandResponse>
    {
    }
}
