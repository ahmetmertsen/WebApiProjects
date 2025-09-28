using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressDetails { get; set; }
    }
}
