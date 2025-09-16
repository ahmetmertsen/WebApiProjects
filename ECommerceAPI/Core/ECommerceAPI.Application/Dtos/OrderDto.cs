using ECommerceAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Dtos
{
    public record OrderDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int AddressId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }

        List<OrderItemDto> Items { get; set; }
    }
}
