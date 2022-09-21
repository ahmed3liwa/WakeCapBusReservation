using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WakecapBusReservation.Domain.Models;

namespace WakecapBusReservation.Infrastracture.Data
{
    public class BusReservationDbContext : DbContext
    {
        public BusReservationDbContext(DbContextOptions<BusReservationDbContext> options) : base(options)
        {

        }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripSeat> TripSeats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
