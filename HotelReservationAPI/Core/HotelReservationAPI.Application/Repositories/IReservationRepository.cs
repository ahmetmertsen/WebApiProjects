using HotelReservationAPI.Application.Repositories.Common;
using HotelReservationAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
    }
}
