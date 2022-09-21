using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models;

namespace WakecapBusReservation.Infrastracture.Config
{
    public class RouteEntityConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.Ignore(r => r.Id);
            builder.HasKey(r => r.Name);
            builder.HasOne(r => r.PickupPoint).WithMany(r => r.PickupRoutes).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.DestinationPoint).WithMany(r => r.DestinationRoutes);
        }
    }
}
