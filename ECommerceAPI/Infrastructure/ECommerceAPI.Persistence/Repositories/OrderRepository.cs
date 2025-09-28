using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ECommerceDbContext _context;

        public OrderRepository(ECommerceDbContext context) : base(context) { _context = context; }

        public async Task<List<Order>> GetAllOrdersByCustomerIdAsync(int CustomerId) => await _context.Orders
            .Where(x => x.CustomerId == CustomerId)
            .Include(o => o.Items)
            .ToListAsync();

        public async Task<Order> GetByIdOrderWithItemsAsync(int id) => await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);

    }
}
