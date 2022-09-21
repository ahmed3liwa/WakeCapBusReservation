using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Exceptions
{
    internal class NoCapacityException : BusinessException
    {
        public NoCapacityException()
        {
            ExMessage = $"no capacity in the trip bus";
        }
    }
}
