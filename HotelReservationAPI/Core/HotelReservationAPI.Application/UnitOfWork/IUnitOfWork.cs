using HotelReservationAPI.Application.Repositories;
using HotelReservationAPI.Application.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public ICustomerRepository CustomerRepository { get; }

        public IRoomRepository RoomRepository { get; }

        public IReservationRepository ReservationRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
