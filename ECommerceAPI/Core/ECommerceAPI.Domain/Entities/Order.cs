using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<OrderItem>? Items { get; set; }
    }
}
