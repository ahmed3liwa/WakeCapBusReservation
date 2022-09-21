using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WakecapBusReservation.Application.Dtos;

namespace WakecapBusReservation.Application.IServices
{
    public interface ITicketService
    {
        Task<CreateTicketSuccessResponseDto> CreateTicket(CreateTicketDto createTicketDto);
        List<UserFrequentTripDto> GetFrequentTripForeachUser();
    }
}
