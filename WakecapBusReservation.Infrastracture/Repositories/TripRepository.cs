using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models;
using WakecapBusReservation.Infrastracture.Data;

namespace WakecapBusReservation.Infrastracture.Repositories
{
    public class TripRepository : GenericRepository<Trip>, ITripRepository
    {
        public TripRepository(BusReservationDbContext busReservationDbContext) : base(busReservationDbContext)
        {

        }
    }
}
