using ECommerceAPI.Application.Dtos;
using ECommerceAPI.Application.Repositories.Common;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        public Task<List<Address>> GetAllByUserIdAsync(int userId);
    }
}
