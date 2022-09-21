using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WakecapBusReservation.API.ViewModels;
using WakecapBusReservation.Application.Dtos;
using WakecapBusReservation.Application.Exceptions;
using WakecapBusReservation.Application.IServices;

namespace WakecapBusReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        #region Fields 
        private readonly IMapper _mapper;
        private readonly ITicketService _ticketService;
        #endregion

        #region CTOR
        public TicketController(IMapper mapper, ITicketService ticketService)
        {
            _mapper = mapper;
            _ticketService = ticketService;
        }
        #endregion

        #region Actions 
        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<CreateTicketSuccessResponseViewModel> CreateTicket(CreateTicketViewModel createTicketVm)
        {
            //validating inputs 
            if (createTicketVm == null)
                throw new MissingParameterException("createTicketVm");
            if (string.IsNullOrEmpty(createTicketVm.TripRoute))
                throw new MissingParameterException("createTicketVm.TripRoute");
            if (createTicketVm.Seats?.Count <= 0)
                throw new MissingParameterException("createTrip.Seats");
            //mapping form vm to dto  
            var createTicketDto = _mapper.Map<CreateTicketDto>(createTicketVm);
            //delgate to ticket service 
            var ticketCreatedDto = await _ticketService.CreateTicket(createTicketDto);
            //mapin form Dto to view Model
            var createdTcketsVm = _mapper.Map<CreateTicketSuccessResponseViewModel>(ticketCreatedDto);
            //return 
            return createdTcketsVm;
        }

        [Authorize]
        [HttpGet]
        [Route("FrequentTripForeachUser")]
        public async Task<List<UserFrequentTripViewModel>> GetFrequentTripForUser()
        {
            //delgate to ticket service 
            var frequentTripUsersDto = _ticketService.GetFrequentTripForeachUser();
            //mapin form Dto to view Model
            var frequentTripUsersVm = _mapper.Map<List<UserFrequentTripViewModel>>(frequentTripUsersDto);
            //return 
            return frequentTripUsersVm;
        }
        #endregion
    }
}

