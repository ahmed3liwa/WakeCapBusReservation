using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models.Base;
using WakecapBusReservation.Infrastracture.Repositories;

namespace WakecapBusReservation.Infrastracture.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BusReservationDbContext _storeContext;
        private Hashtable _repositories;

        public UnitOfWork(BusReservationDbContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _storeContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _storeContext.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();
            var Type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(Type))
            {
                var repositiryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositiryType.MakeGenericType(typeof(TEntity)), _storeContext);
                _repositories.Add(Type, repositoryInstance);
            }
            return (IGenericRepository<TEntity>)_repositories[Type];
        }
    }
}