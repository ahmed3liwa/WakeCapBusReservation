using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WakecapBusReservation.Domain.Models.Base;

namespace WakecapBusReservation.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
