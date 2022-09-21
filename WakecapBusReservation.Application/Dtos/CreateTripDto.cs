using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Dtos
{
    public class CreateTripDto
    {
        public string BusId { get; set; }
        public string RouteId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TicketPrice { get; set; }
        public string Currency { get; set; }

    }
}
