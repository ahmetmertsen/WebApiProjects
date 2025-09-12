using HotelReservationAPI.Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Domain.Entites
{
    public class Reservation : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
