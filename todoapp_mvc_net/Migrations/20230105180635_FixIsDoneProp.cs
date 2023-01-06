using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoappmvcnet.Migrations
{
    /// <inheritdoc />
    public partial class FixIsDoneProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Todos",
                newName: "Id");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDone",
                table: "Todos",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Todos",
                newName: "id");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDone",
                table: "Todos",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
