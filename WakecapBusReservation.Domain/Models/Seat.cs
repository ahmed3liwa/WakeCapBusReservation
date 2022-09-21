using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models.Base;

namespace WakecapBusReservation.Domain.Models
{
    public class Seat : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<TripSeat> TripSeats { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
