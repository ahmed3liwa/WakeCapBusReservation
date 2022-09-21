using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakecapBusReservation.Domain.Models.Base;

namespace WakecapBusReservation.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
