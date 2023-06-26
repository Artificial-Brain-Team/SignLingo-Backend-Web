using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignLingo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SignLingo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "user",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "module",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "module");
        }
    }
}
