using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZayProject.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveAddedOrderRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlideOrder",
                table: "Slides");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Slides",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Slides");

            migrationBuilder.AddColumn<int>(
                name: "SlideOrder",
                table: "Slides",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
