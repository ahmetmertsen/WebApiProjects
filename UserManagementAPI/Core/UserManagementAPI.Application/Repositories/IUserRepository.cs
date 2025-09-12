using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Application.Repositories.Common;
using UserManagementAPI.Domain.Entities;

namespace UserManagementAPI.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
