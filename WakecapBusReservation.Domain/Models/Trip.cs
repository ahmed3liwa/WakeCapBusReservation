using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models.Base;

namespace WakecapBusReservation.Domain.Models
{
    public class Trip : BaseEntity
    {
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public string BusId { get; set; }
        public virtual Bus Bus { get; set; }
        public string RouteId { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<TripSeat> TripSeats { get; set; }
    }
}
