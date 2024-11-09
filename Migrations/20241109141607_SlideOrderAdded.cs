using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZayProject.Migrations
{
    /// <inheritdoc />
    public partial class SlideOrderAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SlideOrder",
                table: "Slides",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlideOrder",
                table: "Slides");
        }
    }
}
