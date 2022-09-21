using Microsoft.EntityFrameworkCore.Migrations;

namespace WakecapBusReservation.Infrastracture.Migrations
{
    public partial class _editticketSeatFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "SeatName",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatName",
                table: "Tickets",
                column: "SeatName",
                principalTable: "Seats",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatName",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "SeatName",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatName",
                table: "Tickets",
                column: "SeatName",
                principalTable: "Seats",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
