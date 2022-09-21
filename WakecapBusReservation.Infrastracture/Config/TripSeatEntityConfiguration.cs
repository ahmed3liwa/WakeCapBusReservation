using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models;

namespace WakecapBusReservation.Infrastracture.Config
{
    public class TripSeatEntityConfiguration : IEntityTypeConfiguration<TripSeat>
    {
        public void Configure(EntityTypeBuilder<TripSeat> builder)
        {
            builder.Ignore(ts => ts.Id);
            builder.HasKey(ts => new { ts.TripId, ts.SeatId });
            builder.HasOne(ts => ts.Trip).WithMany(t => t.TripSeats).HasForeignKey(ts => ts.TripId);
            builder.HasOne(ts => ts.Seat).WithMany(t => t.TripSeats).HasForeignKey(ts => ts.SeatId);
        }
    }
}
