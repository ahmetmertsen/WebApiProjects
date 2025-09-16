using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Common;
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

    }
}
