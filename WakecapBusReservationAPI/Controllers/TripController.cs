using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WakecapBusReservation.API.ViewModels;
using WakecapBusReservation.Application.Dtos;
using WakecapBusReservation.Application.Exceptions;
using WakecapBusReservation.Application.IServices;

namespace WakecapBusReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        #region Fields 
        private readonly IMapper _mapper;
        private readonly ITripService _tripService;
        #endregion

        #region CTOR
        public TripController(IMapper mapper, ITripService tripService)
        {
            _mapper = mapper;
            _tripService = tripService;
        }
        #endregion

        #region Actions 
        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<CreateTripResponseViewModel> CreateTrip(CreateTripViewModel createTripVm)
        {
            //validating inputs 
            if (createTripVm == null)
                throw new MissingParameterException("createTripVm");
            if (string.IsNullOrEmpty(createTripVm?.RouteId))
                throw new MissingParameterException("createTrip.RouteId");
            if (string.IsNullOrEmpty(createTripVm.BusId))
                throw new MissingParameterException("createTrip.BusId");
            //mapping form vm to dto  
            var creatTripDto = _mapper.Map<CreateTripDto>(createTripVm);
            //delgate to trip service 
            var tripCreated = await _tripService.CreateTrip(creatTripDto);
            //return 
            return new CreateTripResponseViewModel() { Created = tripCreated };
        }
        #endregion
    }
}
