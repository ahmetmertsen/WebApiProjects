using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Application.Repositories.Common;
using UserManagementAPI.Domain.Entities.Common;
using UserManagementAPI.Persistence.Contexts;

namespace UserManagementAPI.Persistence.Repositories.Common
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly UserDbContext _context;

        public Repository(UserDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<List<T>> GetAllAsync() => await Table.ToListAsync();

        public async Task<T> GetByIdAsync(int id)  => await Table.FindAsync(id);

        public async Task<EntityEntry<T>> AddAsync(T entity) => await Table.AddAsync(entity);

        public EntityEntry<T> UpdateAsync(T entity) => Table.Update(entity); 

        public async Task<EntityEntry<T>> RemoveAsync(int id) 
        {
            var entity = await Table.FindAsync(id);
            var result = Table.Remove(entity);
            return result;
        }

    }
}
