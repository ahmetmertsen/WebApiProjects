using HotelReservationAPI.Application.Repositories.Common;
using HotelReservationAPI.Domain.Entites.Common;
using HotelReservationAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Persistence.Repositories.Common
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly HotelReservationDbContext _context;

        public Repository(HotelReservationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

   
        public async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<EntityEntry<T>> AddAsync(T entity)
        {
            return await Table.AddAsync(entity);
        }

        public EntityEntry<T> UpdateAsync(T entity)
        {
            return Table.Update(entity);
        }

        public async Task<EntityEntry<T>> RemoveAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            var result = Table.Remove(entity);
            return result;
        }


    }
}
