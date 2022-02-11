using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantQLESS.DAL.Migrations
{
    public partial class Station_Remove_BaseFare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseFare",
                table: "Stations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "BaseFare",
                table: "Stations",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
