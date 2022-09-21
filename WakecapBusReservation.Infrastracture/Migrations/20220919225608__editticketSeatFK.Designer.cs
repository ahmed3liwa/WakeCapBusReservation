﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WakecapBusReservation.Infrastracture.Data;

namespace WakecapBusReservation.Infrastracture.Migrations
{
    [DbContext(typeof(BusReservationDbContext))]
    [Migration("20220919225608__editticketSeatFK")]
    partial class _editticketSeatFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.Bus", b =>
                {
                    b.Property<string>("BusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("DistanceType")
                        .HasColumnType("int");

                    b.Property<string>("ManufactureYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BusId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.Route", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DestinationPointId")
                        .HasColumnType("int");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PickupPointId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("DestinationPointId");

                    b.HasIndex("PickupPointId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.Seat", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SeatName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SeatName");

                    b.HasIndex("TripId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RouteId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("RouteId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.TripSeat", b =>
                {
                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<string>("SeatId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TripId", "SeatId");

                    b.HasIndex("SeatId");

                    b.ToTable("TripSeats");
                });

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.Route", b =>
                {
                    b.HasOne("WakecapBusReservation.Domain.Models.Point", "DestinationPoint")
                        .WithMany("DestinationRoutes")
                        .HasForeignKey("DestinationPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WakecapBusReservation.Domain.Models.Point", "PickupPoint")
                        .WithMany("PickupRoutes")
                        .HasForeignKey("PickupPointId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.Ticket", b =>
                {
                    b.HasOne("WakecapBusReservation.Domain.Models.Seat", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatName");

                    b.HasOne("WakecapBusReservation.Domain.Models.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.Trip", b =>
                {
                    b.HasOne("WakecapBusReservation.Domain.Models.Bus", "Bus")
                        .WithMany("Trips")
                        .HasForeignKey("BusId");

                    b.HasOne("WakecapBusReservation.Domain.Models.Route", "Route")
                        .WithMany("Trips")
                        .HasForeignKey("RouteId");
                });

            modelBuilder.Entity("WakecapBusReservation.Domain.Models.TripSeat", b =>
                {
                    b.HasOne("WakecapBusReservation.Domain.Models.Seat", "Seat")
                        .WithMany("TripSeats")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WakecapBusReservation.Domain.Models.Trip", "Trip")
                        .WithMany("TripSeats")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}