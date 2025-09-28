using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Customers.Commands.Create
{
    public record CreateCustomerCommandResponse(int Id, string FullName)
    {
    }
}
