using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTime.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialTwelfthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotesType",
                table: "Notes",
                newName: "NoteTypes");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "NoteTypes",
                table: "Notes",
                newName: "NotesType");
        }
    }
}
