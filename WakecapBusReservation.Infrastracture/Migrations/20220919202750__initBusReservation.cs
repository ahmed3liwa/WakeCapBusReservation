using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WakecapBusReservation.Infrastracture.Migrations
{
    public partial class _initBusReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusId = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    DistanceType = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    ManufactureYear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PointType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PickupPointId = table.Column<int>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    DestinationPointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Routes_Points_DestinationPointId",
                        column: x => x.DestinationPointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Points_PickupPointId",
                        column: x => x.PickupPointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BusId = table.Column<string>(nullable: true),
                    RouteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    SeatId = table.Column<int>(nullable: false),
                    SeatName = table.Column<string>(nullable: false),
                    TripId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatName",
                        column: x => x.SeatName,
                        principalTable: "Seats",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripSeats",
                columns: table => new
                {
                    SeatId = table.Column<string>(nullable: false),
                    TripId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripSeats", x => new { x.TripId, x.SeatId });
                    table.ForeignKey(
                        name: "FK_TripSeats_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripSeats_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DestinationPointId",
                table: "Routes",
                column: "DestinationPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_PickupPointId",
                table: "Routes",
                column: "PickupPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatName",
                table: "Tickets",
                column: "SeatName");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TripId",
                table: "Tickets",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BusId",
                table: "Trips",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RouteId",
                table: "Trips",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TripSeats_SeatId",
                table: "TripSeats",
                column: "SeatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TripSeats");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Points");
        }
    }
}
