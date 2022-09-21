using Microsoft.Extensions.DependencyInjection;
using WakecapBusReservation.Application.IServices;
using WakecapBusReservation.Application.Services;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Infrastracture.Data;
using WakecapBusReservation.Infrastracture.Repositories;

namespace WakecapBusReservation.Application.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //register services 
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITripService, TripService>();
            services.AddScoped<ITokenService, TokenService>();

            //register unit of work 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //regestring repos 
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();


            return services;
        }
    }
}
