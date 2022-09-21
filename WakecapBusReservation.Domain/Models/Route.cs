using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Enums;
using WakecapBusReservation.Domain.Models.Base;

namespace WakecapBusReservation.Domain.Models
{
    public class Route : BaseEntity
    {
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public int PickupPointId { get; set; }
        public double Distance { get; set; }
        public virtual Point PickupPoint { get; set; }
        public int DestinationPointId { get; set; }
        public virtual Point DestinationPoint { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
