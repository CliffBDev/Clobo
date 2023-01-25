using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clobo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rmproductlines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TeamProductLines_TeamProductLinesId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "TeamTeamProductLines");

            migrationBuilder.DropTable(
                name: "TeamProductLines");

            migrationBuilder.DropIndex(
                name: "IX_Products_TeamProductLinesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TeamProductLinesId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamProductLinesId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamProductLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamProductLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamTeamProductLines",
                columns: table => new
                {
                    TeamProductLinesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTeamProductLines", x => new { x.TeamProductLinesId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_TeamTeamProductLines_TeamProductLines_TeamProductLinesId",
                        column: x => x.TeamProductLinesId,
                        principalTable: "TeamProductLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamTeamProductLines_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TeamProductLinesId",
                table: "Products",
                column: "TeamProductLinesId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTeamProductLines_TeamsId",
                table: "TeamTeamProductLines",
                column: "TeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TeamProductLines_TeamProductLinesId",
                table: "Products",
                column: "TeamProductLinesId",
                principalTable: "TeamProductLines",
                principalColumn: "Id");
        }
    }
}
