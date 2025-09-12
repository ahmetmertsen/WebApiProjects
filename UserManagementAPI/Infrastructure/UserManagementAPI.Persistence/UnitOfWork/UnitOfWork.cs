using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Application.Repositories;
using UserManagementAPI.Application.UnitOfWork;
using UserManagementAPI.Persistence.Contexts;

namespace UserManagementAPI.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _context;
        public IUserRepository UserRepository { get; }

        

        public UnitOfWork(UserDbContext context, IUserRepository userRepository)
        {
            UserRepository = userRepository;
            _context = context;
        }



        public void Dispose() => _context.Dispose();
      
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
