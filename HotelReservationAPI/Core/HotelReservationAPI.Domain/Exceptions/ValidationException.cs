using HotelReservationAPI.Domain.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Domain.Exceptions
{
    public class ValidationException : CustomException
    {
        public ValidationException(string message) : base(message) { }
    }
}
