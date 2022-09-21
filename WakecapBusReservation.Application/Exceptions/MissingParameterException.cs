using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Exceptions
{
    public class MissingParameterException : BusinessException
    {
        public MissingParameterException(string paramName)
        {
            ExMessage = $"Missing Parameter: {paramName}";
        }
    }
}
