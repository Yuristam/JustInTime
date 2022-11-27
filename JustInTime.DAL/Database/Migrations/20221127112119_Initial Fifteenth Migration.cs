using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTime.DAL.Migrations
{
    public partial class InitialFifteenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteType",
                table: "Notes");

            migrationBuilder.CreateTable(
                name: "NoteType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteType", x => x.Id);
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
                        name: "FK_NoteNoteType_NoteType_NoteTypeId",
                        column: x => x.NoteTypeId,
                        principalTable: "NoteType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteNoteType_NotesId",
                table: "NoteNoteType",
                column: "NotesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteNoteType");

            migrationBuilder.DropTable(
                name: "NoteType");

            migrationBuilder.AddColumn<int>(
                name: "NoteType",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
