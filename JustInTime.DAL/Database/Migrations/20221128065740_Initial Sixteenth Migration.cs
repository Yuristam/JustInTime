using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTime.DAL.Migrations
{
    public partial class InitialSixteenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "Notes");

            migrationBuilder.CreateTable(
                name: "ColorHex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorHex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorHexNote",
                columns: table => new
                {
                    ColorHexId = table.Column<int>(type: "int", nullable: false),
                    NotesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorHexNote", x => new { x.ColorHexId, x.NotesId });
                    table.ForeignKey(
                        name: "FK_ColorHexNote_ColorHex_ColorHexId",
                        column: x => x.ColorHexId,
                        principalTable: "ColorHex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorHexNote_Notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorHexNote_NotesId",
                table: "ColorHexNote",
                column: "NotesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorHexNote");

            migrationBuilder.DropTable(
                name: "ColorHex");

            migrationBuilder.AddColumn<int>(
                name: "ColorHex",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
