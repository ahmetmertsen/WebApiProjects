using HotelReservationAPI.Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Domain.Entites
{
    public class Room : BaseEntity
    {
        public int Id { get; set; }
        public long RoomNo { get; set; }
        public int Capacity { get; set; }
        public long Price { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
