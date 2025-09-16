using ECommerceAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
