using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Dtos
{
    public class CreateTicketSuccessDto
    {
        public int TicketId { get; set; }
        public string SeatId { get; set; }
    }
}
