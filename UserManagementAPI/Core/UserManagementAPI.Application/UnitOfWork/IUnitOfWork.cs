using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Application.Repositories;

namespace UserManagementAPI.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository UserRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
