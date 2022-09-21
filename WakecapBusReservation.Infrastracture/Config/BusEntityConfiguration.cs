using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models;

namespace WakecapBusReservation.Infrastracture.Config
{
    public class BusEntityConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.Ignore(b => b.Id);
            builder.HasKey(b => b.BusId);
            //builder.Property(b => b.BusId).HasColumnName("Id");
        }
    }
}
