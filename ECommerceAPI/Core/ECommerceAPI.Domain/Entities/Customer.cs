using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public Cart? Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
