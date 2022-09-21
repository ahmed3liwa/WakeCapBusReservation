using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models.Base;

namespace WakecapBusReservation.Domain.Models
{
    public class Ticket : BaseEntity
    {
        public string Description { get; set; }
        public DateTime ReservationDate { get; set; }
        public decimal Price { get; set; }
        public string UserEmail { get; set; }
        public string SeatId { get; set; }
        public virtual Seat Seat { get; set; }
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
        public string RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}
