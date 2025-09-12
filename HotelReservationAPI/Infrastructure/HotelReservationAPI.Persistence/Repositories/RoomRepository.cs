using HotelReservationAPI.Application.Repositories;
using HotelReservationAPI.Application.Repositories.Common;
using HotelReservationAPI.Domain.Entites;
using HotelReservationAPI.Persistence.Contexts;
using HotelReservationAPI.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Persistence.Repositories
{
    public class RoomRepository : Repository<Room> , IRoomRepository
    {
        public RoomRepository(HotelReservationDbContext context) : base(context) { }
    }
}
