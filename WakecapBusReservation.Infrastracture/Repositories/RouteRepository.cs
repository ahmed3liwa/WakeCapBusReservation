using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models;
using WakecapBusReservation.Infrastracture.Data;

namespace WakecapBusReservation.Infrastracture.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        #region Fileds 
        #endregion

        #region CTOR
        public RouteRepository(BusReservationDbContext busReservationDbContext) : base(busReservationDbContext)
        {

        }
        #endregion

        #region Methods

        #endregion
    }
}
