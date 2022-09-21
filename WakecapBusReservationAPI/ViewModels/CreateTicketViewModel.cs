using System.Collections.Generic;

namespace WakecapBusReservation.API.ViewModels
{
    public class CreateTicketViewModel
    {
        public string UserEmail { get; set; }
        public string TripRoute { get; set; }
        public List<string> Seats { get; set; }
    }
}
