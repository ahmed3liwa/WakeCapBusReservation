using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Exceptions
{
    public class InternalServerErrorException : BusinessException
    {
        public InternalServerErrorException(string extMessage = "")
        {
            ExMessage = $"Internal server Error , {extMessage}";
        }
    }
}
