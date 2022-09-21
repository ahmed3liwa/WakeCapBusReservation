using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WakecapBusReservation.Application.Dtos;
using WakecapBusReservation.Application.Exceptions;
using WakecapBusReservation.Application.IServices;
using WakecapBusReservation.Domain.Enums;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models;

namespace WakecapBusReservation.Application.Services
{
    public class TripService : ITripService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITripRepository _tripRepository;

        #endregion

        #region CTOR
        public TripService(IMapper mapper, IUnitOfWork unitOfWork
            , IConfiguration configuration, ITripRepository tripRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _tripRepository = tripRepository;
        }
        #endregion

        #region Methods
        public async Task<bool> CreateTrip(CreateTripDto createTripDto)
        {
            //loading trip route
            var triproute = await _unitOfWork.Repository<Route>().GetByIdAsync(createTripDto.RouteId);
            //validate trip route existance 
            if (triproute == null)
                throw new EntityNotFoundException("Route", createTripDto.RouteId);
            //loading trip bus 
            var tripBus = await _unitOfWork.Repository<Bus>().GetByIdAsync(createTripDto.BusId);
            //validate trip bus existace 
            if (tripBus == null)
                throw new EntityNotFoundException("Bus", createTripDto.BusId);
            //validating trip datetime 
            if (createTripDto.DateTime < DateTime.Now)
                throw new CreateTripInPastException();
            //validate short distance againest bus 
            if (triproute.Distance < _configuration.GetValue<double>("maxShorTripDistance")
                && tripBus.DistanceType == DistanceTypes.LongDistance)
                throw new InvalidTripBusVsTripRouteException(DistanceTypes.ShortDistance);
            //validate long distance againest bus 
            if (triproute.Distance >= _configuration.GetValue<double>("maxShorTripDistance")
                && tripBus.DistanceType == DistanceTypes.ShortDistance)
                throw new InvalidTripBusVsTripRouteException(DistanceTypes.LongDistance);
            //maping from dto to model 
            var trip = _mapper.Map<Trip>(createTripDto);
            //adding trip 
            _tripRepository.Add(trip);
            //commit to data base 
            await _unitOfWork.SaveChangesAsync();
            //return 
            return true;
        }
        #endregion
    }
}
