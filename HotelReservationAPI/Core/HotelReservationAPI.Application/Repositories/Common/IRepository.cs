using HotelReservationAPI.Domain.Entites.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationAPI.Application.Repositories.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<EntityEntry<T>> AddAsync(T entity);
        EntityEntry<T> UpdateAsync(T entity);
        Task<EntityEntry<T>> RemoveAsync(int id);

    }
}
