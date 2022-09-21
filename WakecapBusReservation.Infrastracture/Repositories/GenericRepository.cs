using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models.Base;
using WakecapBusReservation.Infrastracture.Data;

namespace WakecapBusReservation.Infrastracture.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly BusReservationDbContext _storeContext;

        public GenericRepository(BusReservationDbContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            try
            {
                return await _storeContext.Set<T>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IQueryable<T> GetAll()
        {
            try
            {
                return _storeContext.Set<T>().AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _storeContext.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                return await _storeContext.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public T Add(T entity)
        {
            _storeContext.Add<T>(entity);

            return entity;
        }

        public void Update(T entity)
        {
            _storeContext.Attach<T>(entity);
            _storeContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _storeContext.Set<T>().Remove(entity);
        }


    }
}
