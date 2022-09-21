using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Application.Dtos;
using WakecapBusReservation.Domain.Models;

namespace WakecapBusReservation.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateTripDto, Trip>()
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ForMember(dest => dest.BusId, opt => opt.MapFrom(src => src.BusId))
                .ForMember(dest => dest.RouteId, opt => opt.MapFrom(src => src.RouteId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.TicketPrice))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DateTime));

        }
    }
}
