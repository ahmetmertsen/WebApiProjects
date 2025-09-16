using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Dtos
{
    public record CartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        List<CartItemDto> Items { get; set; }
    }
}
