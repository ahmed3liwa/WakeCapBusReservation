using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakecapBusReservation.Infrastracture.Data;

namespace WakecapBusReservation.Infrastracture.SeedData
{
    public class BusReservationContextSeed
    {
        public static async Task SeedAsync(BusReservationDbContext dbContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!dbContext.Buses.Any())
                {
                    dbContext.Buses.Add(new Domain.Models.Bus()
                    {
                        BusId = "B-1",
                        Capacity = 20,
                        DistanceType = Domain.Enums.DistanceTypes.ShortDistance,
                        Model = "Mercedes",
                        ManufactureYear = "2020"

                    });
                    dbContext.Buses.Add(new Domain.Models.Bus()
                    {
                        BusId = "B-2",
                        Capacity = 20,
                        DistanceType = Domain.Enums.DistanceTypes.LongDistance,
                        Model = "Mercedes",
                        ManufactureYear = "2022"

                    });
                    await dbContext.SaveChangesAsync();
                }
                if (!dbContext.Points.Any())
                {
                    dbContext.Points.Add(new Domain.Models.Point()
                    {
                        Description = "Cairo Pick up Point",
                        Latitude = 30.033333,
                        Longitude = 31.233334,
                        Name = "Cairo",
                        PointType = Domain.Enums.PointTypes.Pickup

                    });
                    dbContext.Points.Add(new Domain.Models.Point()
                    {
                        Description = "Alexandria Pick up Point",
                        Latitude = 33.033333,
                        Longitude = 32.233334,
                        Name = "Alexandria",
                        PointType = Domain.Enums.PointTypes.Destination

                    });
                    dbContext.Points.Add(new Domain.Models.Point()
                    {
                        Description = "Aswan Pick up Point",
                        Latitude = 31.033333,
                        Longitude = 36.233334,
                        Name = "Aswan",
                        PointType = Domain.Enums.PointTypes.Destination

                    });
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Seats.Any())
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        dbContext.Seats.Add(new Domain.Models.Seat()
                        {
                            Name = $"A{i}"

                        });
                    }
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Routes.Any())
                {

                    dbContext.Routes.Add(new Domain.Models.Route()
                    {
                        Name = "Cairo-Alexandria",
                        DestinationPoint = dbContext.Points.FirstOrDefault(p => p.Name == "Alexandria" && p.PointType == Domain.Enums.PointTypes.Destination),
                        IsActive = true,
                        PickupPoint = dbContext.Points.FirstOrDefault(p => p.Name == "Cairo" && p.PointType == Domain.Enums.PointTypes.Pickup),
                        Distance = 90d
                    });

                    dbContext.Routes.Add(new Domain.Models.Route()
                    {
                        Name = "Cairo-Aswan",
                        DestinationPoint = dbContext.Points.FirstOrDefault(p => p.Name == "Aswan" && p.PointType == Domain.Enums.PointTypes.Destination),
                        IsActive = true,
                        PickupPoint = dbContext.Points.FirstOrDefault(p => p.Name == "Cairo" && p.PointType == Domain.Enums.PointTypes.Pickup),
                        Distance = 150d
                    });
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<BusReservationContextSeed>();
                logger.LogError(ex, "Something went wrong with your request");
            }
        }
    }
}
