using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Exceptions
{
    public class CreateTripInPastException : BusinessException
    {
        public CreateTripInPastException()
        {
            ExMessage = $"Error. Can not craete trip in past";
        }
    }
}
