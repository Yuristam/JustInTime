using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTime.DAL.Migrations
{
    public partial class InitialSeventeenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorHexNote_ColorHex_ColorHexId",
                table: "ColorHexNote");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteNoteType_NoteType_NoteTypeId",
                table: "NoteNoteType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteType",
                table: "NoteType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColorHex",
                table: "ColorHex");

            migrationBuilder.RenameTable(
                name: "NoteType",
                newName: "NoteTypes");

            migrationBuilder.RenameTable(
                name: "ColorHex",
                newName: "ColorHexes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteTypes",
                table: "NoteTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColorHexes",
                table: "ColorHexes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorHexNote_ColorHexes_ColorHexId",
                table: "ColorHexNote",
                column: "ColorHexId",
                principalTable: "ColorHexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteNoteType_NoteTypes_NoteTypeId",
                table: "NoteNoteType",
                column: "NoteTypeId",
                principalTable: "NoteTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorHexNote_ColorHexes_ColorHexId",
                table: "ColorHexNote");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteNoteType_NoteTypes_NoteTypeId",
                table: "NoteNoteType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteTypes",
                table: "NoteTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColorHexes",
                table: "ColorHexes");

            migrationBuilder.RenameTable(
                name: "NoteTypes",
                newName: "NoteType");

            migrationBuilder.RenameTable(
                name: "ColorHexes",
                newName: "ColorHex");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteType",
                table: "NoteType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColorHex",
                table: "ColorHex",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorHexNote_ColorHex_ColorHexId",
                table: "ColorHexNote",
                column: "ColorHexId",
                principalTable: "ColorHex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteNoteType_NoteType_NoteTypeId",
                table: "NoteNoteType",
                column: "NoteTypeId",
                principalTable: "NoteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
