using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Dtos
{
    public class CreateTicketSuccessResponseDto
    {
        public string UserEmail { get; set; }
        public string BusId { get; set; }
        public decimal Price { get; set; }
        public List<CreateTicketSuccessDto> Tickets { get; set; }
    }
}
