using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Enums;
using WakecapBusReservation.Domain.Models.Base;

namespace WakecapBusReservation.Domain.Models
{
    public class Point : BaseEntity
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public PointTypes PointType { get; set; }
        public virtual ICollection<Route> PickupRoutes { get; set; }
        public virtual ICollection<Route> DestinationRoutes { get; set; }

    }
}
