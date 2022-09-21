using Microsoft.EntityFrameworkCore.Migrations;

namespace WakecapBusReservation.Infrastracture.Migrations
{
    public partial class _addingroutrTicketFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouteId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RouteId",
                table: "Tickets",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Routes_RouteId",
                table: "Tickets",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Routes_RouteId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_RouteId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Tickets");
        }
    }
}
