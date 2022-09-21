using Microsoft.EntityFrameworkCore.Migrations;

namespace WakecapBusReservation.Infrastracture.Migrations
{
    public partial class _renameticketSeatFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatName",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SeatName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatName",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "SeatId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "SeatName",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatName",
                table: "Tickets",
                column: "SeatName");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatName",
                table: "Tickets",
                column: "SeatName",
                principalTable: "Seats",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
