using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Enums;
using WakecapBusReservation.Domain.Models.Base;

namespace WakecapBusReservation.Domain.Models
{
    public class Bus : BaseEntity
    {
        public string BusId { get; set; }
        public int Capacity { get; set; }
        public DistanceTypes DistanceType { get; set; }
        public string Model { get; set; }
        public string ManufactureYear { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
