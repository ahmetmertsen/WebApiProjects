using HotelReservationAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public long RoomNo { get; set; }
        public int Capacity { get; set; }
        public long Price { get; set; }

    }
}
