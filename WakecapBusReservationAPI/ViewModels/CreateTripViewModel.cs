using System;

namespace WakecapBusReservation.API.ViewModels
{
    public class CreateTripViewModel
    {
        public string BusId { get; set; }
        public string RouteId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TicketPrice { get; set; }
        public string Currency { get; set; }

    }
}
