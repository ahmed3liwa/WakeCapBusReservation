using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models;
using WakecapBusReservation.Infrastracture.Data;

namespace WakecapBusReservation.Infrastracture.Repositories
{
    public class BusRepository : GenericRepository<Bus>, IBusRepository
    {
        public BusRepository(BusReservationDbContext busReservationDbContext) : base(busReservationDbContext)
        {

        }
    }
}
