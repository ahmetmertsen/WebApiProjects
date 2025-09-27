using ECommerceAPI.Application.Repositories.Common;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<List<Order>> GetAllOrdersByUserIdAsync(int UserId);

        public Task<Order> GetByIdOrderWithItemsAsync(int id);

    }
}
