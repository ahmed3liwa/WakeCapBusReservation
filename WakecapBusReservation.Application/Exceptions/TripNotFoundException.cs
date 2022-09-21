using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Exceptions
{
    internal class TripNotFoundException : BusinessException
    {
        public TripNotFoundException()
        {
            ExMessage = $"No available trips found for today";
        }
    }
}
