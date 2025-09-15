using HotelReservationAPI.Application.Repositories;
using HotelReservationAPI.Domain.Entites;
using HotelReservationAPI.Persistence.Contexts;
using HotelReservationAPI.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer> ,ICustomerRepository
    {
        private readonly HotelReservationDbContext _context;
        public CustomerRepository(HotelReservationDbContext context) : base(context) { _context = context; }

        public async Task<Customer?> GetByIdentityNumberAsync(string identityNumber)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.IdentityNumber == identityNumber);
        }


    }
}
