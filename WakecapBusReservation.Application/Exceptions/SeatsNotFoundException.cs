using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Exceptions
{
    public class SeatsNotFoundException : BusinessException
    {
        public SeatsNotFoundException(List<string> missingSeats)
        {
            ExMessage = $"one or more seat/s did not found in db. Missing seats ids: {string.Join(", ", missingSeats.ToArray())}";
        }
    }
}
