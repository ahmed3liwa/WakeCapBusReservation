using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WakecapBusReservation.Domain.Models.Idenitiy;
using WakecapBusReservation.Infrastracture.Data;
using WakecapBusReservation.Infrastracture.Identity;
using WakecapBusReservation.Infrastracture.SeedData;

namespace WakecapBusReservation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerfactory = scope.ServiceProvider.GetService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<BusReservationDbContext>();
                    await context.Database.MigrateAsync();
                    await BusReservationContextSeed.SeedAsync(context, loggerfactory);
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var identityContext = services.GetRequiredService<IdentityContext>();
                    await identityContext.Database.MigrateAsync();
                    await AppIdentityDbContextSeed.SeedUserData(userManager);
                }
                catch (Exception ex)
                {
                    var loger = loggerfactory.CreateLogger<BusReservationDbContext>();
                    loger.LogError(ex, "Something went wrong during migration");
                }
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
