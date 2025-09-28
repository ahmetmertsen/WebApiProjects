using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Addresses.Commands.Create
{
    public record CreateAddressCommandResponse(int Id, int CustomerId, string City, string District, string AddressDetails)
    {
    }
}
