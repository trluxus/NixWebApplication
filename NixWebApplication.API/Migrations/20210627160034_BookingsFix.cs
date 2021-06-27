using Microsoft.EntityFrameworkCore.Migrations;

namespace NixWebApplication.API.Migrations
{
    public partial class BookingsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomtId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomtId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomtId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "RoomtId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomtId",
                table: "Bookings",
                column: "RoomtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomtId",
                table: "Bookings",
                column: "RoomtId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
