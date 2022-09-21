using AutoMapper;
using WakecapBusReservation.API.ViewModels;
using WakecapBusReservation.Application.Dtos;

namespace WakecapBusReservation.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateTripViewModel, CreateTripDto>().ReverseMap();

            CreateMap<CreateTicketViewModel, CreateTicketDto>().ReverseMap();

            CreateMap<CreateTicketSuccessDto, CreateTicketSuccessViewModel>().ReverseMap();
            CreateMap<CreateTicketSuccessDto, CreateTicketSuccessViewModel>().ReverseMap();

            CreateMap<CreateTicketSuccessResponseDto, CreateTicketSuccessResponseViewModel>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.ToString()))
                .ReverseMap();
            CreateMap<UserFrequentTripViewModel, UserFrequentTripDto>().ReverseMap();
        }

    }
}
