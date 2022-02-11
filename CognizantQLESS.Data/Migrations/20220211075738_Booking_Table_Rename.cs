using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantQLESS.DAL.Migrations
{
    public partial class Booking_Table_Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    TravelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportCardId = table.Column<int>(nullable: false),
                    OriginStationId = table.Column<int>(nullable: false),
                    DestinationStationId = table.Column<int>(nullable: false),
                    TravelDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.TravelId);
                    table.ForeignKey(
                        name: "FK_Travels_Stations_DestinationStationId",
                        column: x => x.DestinationStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Travels_Stations_OriginStationId",
                        column: x => x.OriginStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Travels_TransportCards_TransportCardId",
                        column: x => x.TransportCardId,
                        principalTable: "TransportCards",
                        principalColumn: "TransportCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_DestinationStationId",
                table: "Travels",
                column: "DestinationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_OriginStationId",
                table: "Travels",
                column: "OriginStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_TransportCardId",
                table: "Travels",
                column: "TransportCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DestinationStationId = table.Column<int>(type: "int", nullable: false),
                    OriginStationId = table.Column<int>(type: "int", nullable: false),
                    TransportCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Stations_DestinationStationId",
                        column: x => x.DestinationStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Stations_OriginStationId",
                        column: x => x.OriginStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_TransportCards_TransportCardId",
                        column: x => x.TransportCardId,
                        principalTable: "TransportCards",
                        principalColumn: "TransportCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DestinationStationId",
                table: "Bookings",
                column: "DestinationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OriginStationId",
                table: "Bookings",
                column: "OriginStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TransportCardId",
                table: "Bookings",
                column: "TransportCardId");
        }
    }
}
