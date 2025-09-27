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
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly ECommerceDbContext _context;
        public CartRepository(ECommerceDbContext context) : base(context) { _context = context; }

        public async Task<Cart?> GetByUserIdAsync(int userId) => await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId);


    }
}
