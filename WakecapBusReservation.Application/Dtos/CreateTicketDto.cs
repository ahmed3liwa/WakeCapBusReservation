using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Dtos
{
    public class CreateTicketDto
    {
        public string UserEmail { get; set; }
        public string TripRoute { get; set; }
        public List<string> Seats { get; set; }
    }
}
