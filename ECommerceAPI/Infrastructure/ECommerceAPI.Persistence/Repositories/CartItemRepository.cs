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
    public class CartItemRepository : Repository<CartItem> , ICartItemRepository
    {
        private readonly ECommerceDbContext _context;

        public CartItemRepository(ECommerceDbContext context) : base(context) { _context = context; }

        public async Task<List<CartItem>> GetAllByCartIdAsync(int cartId) => await _context.CartItems.Where(x => x.CartId == cartId).ToListAsync();
    }
}
