using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakecapBusReservation.Domain.Models;

namespace WakecapBusReservation.Test.Data
{
    public class MockData
    {
        public static List<Route> Routes()
        {
            List<Route> routes = new List<Route>();
            routes.Add(new Domain.Models.Route()
            {
                Name = "Cairo-Alexandria",
                DestinationPoint = Points().FirstOrDefault(p => p.Name == "Alexandria" && p.PointType == Domain.Enums.PointTypes.Destination),
                IsActive = true,
                PickupPoint = Points().FirstOrDefault(p => p.Name == "Cairo" && p.PointType == Domain.Enums.PointTypes.Pickup),
                Distance = 90d
            });

            routes.Add(new Domain.Models.Route()
            {
                Name = "Cairo-Aswan",
                DestinationPoint = Points().FirstOrDefault(p => p.Name == "Aswan" && p.PointType == Domain.Enums.PointTypes.Destination),
                IsActive = true,
                PickupPoint = Points().FirstOrDefault(p => p.Name == "Cairo" && p.PointType == Domain.Enums.PointTypes.Pickup),
                Distance = 150d
            });
            return routes;
        }


        public static List<Point> Points()
        {
            List<Point> points = new List<Point>();
            points.Add(new Domain.Models.Point()
            {
                Description = "Cairo Pick up Point",
                Latitude = 30.033333,
                Longitude = 31.233334,
                Name = "Cairo",
                PointType = Domain.Enums.PointTypes.Pickup

            });
            points.Add(new Domain.Models.Point()
            {
                Description = "Alexandria Pick up Point",
                Latitude = 33.033333,
                Longitude = 32.233334,
                Name = "Alexandria",
                PointType = Domain.Enums.PointTypes.Destination

            });
            points.Add(new Domain.Models.Point()
            {
                Description = "Aswan Pick up Point",
                Latitude = 31.033333,
                Longitude = 36.233334,
                Name = "Aswan",
                PointType = Domain.Enums.PointTypes.Destination

            });
            return points;
        }

        public static List<Seat> Seats()
        {
            List<Seat> seats = new List<Seat>();
            for (int i = 1; i <= 20; i++)
            {
                seats.Add(new Domain.Models.Seat()
                {
                    Name = $"A{i}"

                });
            }
            return seats;
        }

        public static List<Bus> Buses()
        {
            List<Bus> buses = new List<Bus>();

            buses.Add(new Domain.Models.Bus()
            {
                BusId = "B-1",
                Capacity = 20,
                DistanceType = Domain.Enums.DistanceTypes.ShortDistance,
                Model = "Mercedes",
                ManufactureYear = "2020"

            });
            buses.Add(new Domain.Models.Bus()
            {
                BusId = "B-2",
                Capacity = 20,
                DistanceType = Domain.Enums.DistanceTypes.LongDistance,
                Model = "Mercedes",
                ManufactureYear = "2022"

            });
            return buses;
        }

        public static List<Trip> Trips()
        {
            List<Trip> trips = new List<Trip>();
            trips.Add(new Domain.Models.Trip()
            {
                Id = 1,
                BusId = "B-1",
                Bus = Buses().FirstOrDefault(b => b.BusId == "B-1"),
                Currency = "EG",
                Date = new DateTime(2022, 9, 21, 23, 23, 59),
                Price = 100,
                RouteId = "Cairo-Alexandria",
                Route = Routes().FirstOrDefault(r => r.Name == "Cairo-Alexandria"),
                TripSeats = new List<TripSeat>()
            });

            trips.Add(new Domain.Models.Trip()
            {
                Id = 2,
                BusId = "B-2",
                Bus = Buses().FirstOrDefault(b => b.BusId == "B-2"),
                Currency = "EG",
                Date = new DateTime(2022, 9, 21, 23, 23, 59),
                Price = 200,
                RouteId = "Cairo-Aswan",
                Route = Routes().FirstOrDefault(r => r.Name == "Cairo-Aswan"),
                TripSeats = new List<TripSeat>()
            });

            return trips;
        }

        public static List<Ticket> Tickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Alexandria"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Alexandria"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Alexandria"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Alexandria"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Alexandria"
            });
            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Alexandria"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Alexandria"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Alexandria"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Alexandria"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Aswan"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Aswan"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Aswan"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Aswan"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Aswan"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa15@gmail.com",
                RouteId = "Cairo-Aswan"
            });




            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa14@gmail.com",
                RouteId = "Cairo-Alexandria"
            });


            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa14@gmail.com",
                RouteId = "Cairo-Alexandria"
            });


            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa14@gmail.com",
                RouteId = "Cairo-Alexandria"
            });

            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa14@gmail.com",
                RouteId = "Cairo-Aswan"
            });


            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa14@gmail.com",
                RouteId = "Cairo-Aswan"
            });


            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa14@gmail.com",
                RouteId = "Cairo-Aswan"
            });


            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa14@gmail.com",
                RouteId = "Cairo-Aswan"
            });


            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa14@gmail.com",
                RouteId = "Cairo-Aswan"
            });


            tickets.Add(new Ticket()
            {
                UserEmail = "AhmedEliwa14@gmail.com",
                RouteId = "Cairo-Aswan"
            });

            return tickets;
        }
    }
}
