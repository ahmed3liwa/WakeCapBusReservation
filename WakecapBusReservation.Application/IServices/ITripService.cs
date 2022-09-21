using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WakecapBusReservation.Application.Dtos;

namespace WakecapBusReservation.Application.IServices
{
    public interface ITripService
    {
        Task<bool> CreateTrip(CreateTripDto createTripDto);
    }
}
