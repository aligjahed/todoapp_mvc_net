using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoappmvcnet.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbSetNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_UserId",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "TodoAppTodos");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_UserId",
                table: "TodoAppTodos",
                newName: "IX_TodoAppTodos_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoAppTodos",
                table: "TodoAppTodos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoAppTodos_AspNetUsers_UserId",
                table: "TodoAppTodos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoAppTodos_AspNetUsers_UserId",
                table: "TodoAppTodos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoAppTodos",
                table: "TodoAppTodos");

            migrationBuilder.RenameTable(
                name: "TodoAppTodos",
                newName: "Todos");

            migrationBuilder.RenameIndex(
                name: "IX_TodoAppTodos_UserId",
                table: "Todos",
                newName: "IX_Todos_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_UserId",
                table: "Todos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
