using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public Cart? Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
