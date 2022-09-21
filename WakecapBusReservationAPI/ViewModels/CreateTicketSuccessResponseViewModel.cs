using System.Collections.Generic;

namespace WakecapBusReservation.API.ViewModels
{
    public class CreateTicketSuccessResponseViewModel
    {
        public string UserEmail { get; set; }
        public string BusId { get; set; }
        public string Price { get; set; }
        public List<CreateTicketSuccessViewModel> Tickets { get; set; }
    }
}
