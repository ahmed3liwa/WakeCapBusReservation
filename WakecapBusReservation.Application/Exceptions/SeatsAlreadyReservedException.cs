using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Exceptions
{
    public class SeatsAlreadyReservedException : BusinessException
    {
        public SeatsAlreadyReservedException(List<string> reservedSeats)
        {
            ExMessage = $"Seats {string.Join(", ", reservedSeats.ToArray())} already reserved";
        }
    }
}
