using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models.Base;

namespace WakecapBusReservation.Domain.Models
{
    public class TripSeat : BaseEntity
    {
        public string SeatId { get; set; }
        public Seat Seat { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
