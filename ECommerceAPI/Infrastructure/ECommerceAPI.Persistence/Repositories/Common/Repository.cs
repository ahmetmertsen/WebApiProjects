using ECommerceAPI.Application.Repositories.Common;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Domain.Exceptions;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories.Common
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ECommerceDbContext _context;

        public Repository(ECommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<List<T>> GetAllAsync() => await Table.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await Table.FindAsync(id);

        public async Task<EntityEntry<T>> AddAsync(T entity) => await Table.AddAsync(entity);

        public EntityEntry<T> Update(T entity) => Table.Update(entity);

        public async Task<EntityEntry<T>> RemoveAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException("Entity bulunamadı...");
            }
            var result = Table.Remove(entity);
            return result;
        }
        
    }
}
