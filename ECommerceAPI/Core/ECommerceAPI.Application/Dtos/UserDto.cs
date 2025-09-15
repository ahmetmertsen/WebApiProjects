using ECommerceAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Dtos
{
    public record UserDto
    {
        public string FullName { get; set; }

        public UserRole Role { get; set; }
    }
}
