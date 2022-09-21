using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models;

namespace WakecapBusReservation.Infrastracture.Config
{
    public class TicketEntityConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Seat).WithMany(t => t.Tickets).HasForeignKey(ts => ts.SeatId);
            builder.HasOne(t => t.Trip).WithMany(t => t.Tickets);
            builder.HasOne(t => t.Route).WithMany(t => t.Tickets).HasForeignKey(t => t.RouteId);
        }
    }
}
