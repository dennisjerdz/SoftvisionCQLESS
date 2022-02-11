using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantQLESS.DAL.Migrations
{
    public partial class Transport_Card_Serial_Number : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "TransportCards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "TransportCards");
        }
    }
}
