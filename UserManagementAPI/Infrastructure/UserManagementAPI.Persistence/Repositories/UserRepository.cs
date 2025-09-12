using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Application.Repositories;
using UserManagementAPI.Domain.Entities;
using UserManagementAPI.Persistence.Contexts;
using UserManagementAPI.Persistence.Repositories.Common;

namespace UserManagementAPI.Persistence.Repositories
{
    public class UserRepository : Repository<User> ,IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context) { }

    }
}
