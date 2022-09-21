using System;
using System.Collections.Generic;
using System.Text;

namespace WakecapBusReservation.Application.Exceptions
{
    public class EntityNotFoundException : BusinessException
    {
        public EntityNotFoundException(string entityName, string givenValue)
        {
            ExMessage = $"No {entityName} found for value : {givenValue}";
        }
    }
}
