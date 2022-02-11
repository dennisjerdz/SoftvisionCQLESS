using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantQLESS.DAL.Migrations
{
    public partial class New_Table_Load_History : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoadHistories",
                columns: table => new
                {
                    LoadHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportCardId = table.Column<int>(nullable: false),
                    Type = table.Column<short>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    RunningBalance = table.Column<float>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadHistories", x => x.LoadHistoryId);
                    table.ForeignKey(
                        name: "FK_LoadHistories_TransportCards_TransportCardId",
                        column: x => x.TransportCardId,
                        principalTable: "TransportCards",
                        principalColumn: "TransportCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoadHistories_TransportCardId",
                table: "LoadHistories",
                column: "TransportCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadHistories");
        }
    }
}
