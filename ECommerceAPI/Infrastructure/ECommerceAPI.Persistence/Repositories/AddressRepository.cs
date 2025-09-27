using ECommerceAPI.Application.Dtos;
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
    public class AddressRepository : Repository<Address> , IAddressRepository
    {
        private ECommerceDbContext _context;

        public AddressRepository(ECommerceDbContext context) : base(context) { _context = context; }

        public async Task<List<Address>> GetAllByUserIdAsync(int userId) => await _context.Addresses
            .Where(x => x.UserId == userId).ToListAsync();
    }
}
