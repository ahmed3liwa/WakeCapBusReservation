using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models;

namespace WakecapBusReservation.Infrastracture.Config
{
    public class TripEntityConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Bus).WithMany(r => r.Trips);
            builder.HasOne(t => t.Route).WithMany(r => r.Trips);
        }
    }
}
