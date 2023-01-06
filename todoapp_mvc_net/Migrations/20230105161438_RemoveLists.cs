using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoappmvcnet.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_TodoLists_TodoListid",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_Todos_TodoListid",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "TodoListid",
                table: "Todos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TodoListid",
                table: "Todos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_TodoListid",
                table: "Todos",
                column: "TodoListid");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_TodoLists_TodoListid",
                table: "Todos",
                column: "TodoListid",
                principalTable: "TodoLists",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
