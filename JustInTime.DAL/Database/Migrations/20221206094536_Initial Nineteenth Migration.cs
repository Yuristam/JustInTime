using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTime.DAL.Migrations
{
    public partial class InitialNineteenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notes");

            migrationBuilder.CreateTable(
                name: "ColorHexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorHexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTypes", x => x.Id);
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
                        name: "FK_ColorHexNote_ColorHexes_ColorHexId",
                        column: x => x.ColorHexId,
                        principalTable: "ColorHexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorHexNote_Notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteNoteType",
                columns: table => new
                {
                    NoteTypeId = table.Column<int>(type: "int", nullable: false),
                    NotesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteNoteType", x => new { x.NoteTypeId, x.NotesId });
                    table.ForeignKey(
                        name: "FK_NoteNoteType_Notes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteNoteType_NoteTypes_NoteTypeId",
                        column: x => x.NoteTypeId,
                        principalTable: "NoteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorHexNote_NotesId",
                table: "ColorHexNote",
                column: "NotesId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteNoteType_NotesId",
                table: "NoteNoteType",
                column: "NotesId");
        }
    }
}
