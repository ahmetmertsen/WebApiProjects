using HotelReservationAPI.Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Domain.Entites
{
    public class Customer : BaseEntity
    {
        public string IdentityNumber { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public string PhoneNumber {  get; set; }

        public ICollection<Reservation> Reservations { get; set; }



    }
}
