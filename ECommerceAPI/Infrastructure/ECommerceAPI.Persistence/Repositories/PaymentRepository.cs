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
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly ECommerceDbContext _context;

        public PaymentRepository(ECommerceDbContext context) : base(context) { _context = context; }

        public async Task<Payment?> GetPaymentByOrderIdAsync(int OrderId) => await _context.Payments.FirstOrDefaultAsync(x => x.OrderId == OrderId);
        
    }
}
