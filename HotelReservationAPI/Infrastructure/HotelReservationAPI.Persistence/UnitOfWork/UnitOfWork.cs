using HotelReservationAPI.Application.Repositories;
using HotelReservationAPI.Application.UnitOfWork;
using HotelReservationAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelReservationDbContext _context;

        public ICustomerRepository CustomerRepository { get; }
        public IRoomRepository RoomRepository { get; }
        public IReservationRepository ReservationRepository { get; }

        public void Dispose() => _context.Dispose();

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
