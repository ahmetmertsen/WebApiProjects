using ECommerceAPI.Domain.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Exceptions
{
    public class CreateUserFailedException : BaseException
    {
        public CreateUserFailedException(string message) : base(message) { }
    }
}
