using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Enums;

namespace WakecapBusReservation.Application.Exceptions
{
    public class InvalidTripBusVsTripRouteException : BusinessException
    {
        public InvalidTripBusVsTripRouteException(DistanceTypes distanceTypes)
        {
            switch (distanceTypes)
            {
                case DistanceTypes.LongDistance:
                    ExMessage = $"Error. Log distance bus has been selcted for short distance route ";
                    break;
                case DistanceTypes.ShortDistance:
                    ExMessage = $"Error. short distance bus has been selcted for log distance route ";
                    break;
                default:
                    ExMessage = $"Error.";
                    break;
            }
        }
    }
}
