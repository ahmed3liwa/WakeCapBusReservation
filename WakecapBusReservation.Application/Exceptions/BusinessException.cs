using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Exceptions
{
    public class BusinessException : Exception
    {
        public  string ExMessage { get; set; }
    }
}
