using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAPI.Domain.Entities.Common;

namespace UserManagementAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Email { get; set; }

        public String Address { get; set; }
    }
}
