using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustInTime.DAL.Migrations
{
    public partial class Initialtwentithmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListToDo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CheckLists",
                newName: "CheckListId");

            migrationBuilder.AddColumn<int>(
                name: "CheckListId",
                table: "ToDos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CheckLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CheckLists",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_CheckListId",
                table: "ToDos",
                column: "CheckListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_CheckLists_CheckListId",
                table: "ToDos",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "CheckListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_CheckLists_CheckListId",
                table: "ToDos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_CheckListId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "CheckListId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CheckLists");

            migrationBuilder.RenameColumn(
                name: "CheckListId",
                table: "CheckLists",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "CheckListToDo",
                columns: table => new
                {
                    CheckListId = table.Column<int>(type: "int", nullable: false),
                    ToDoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListToDo", x => new { x.CheckListId, x.ToDoId });
                    table.ForeignKey(
                        name: "FK_CheckListToDo_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckListToDo_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckListToDo_ToDoId",
                table: "CheckListToDo",
                column: "ToDoId");
        }
    }
}
