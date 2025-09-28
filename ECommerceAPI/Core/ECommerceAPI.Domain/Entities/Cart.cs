using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<CartItem>? Items { get; set; }
    }
}
