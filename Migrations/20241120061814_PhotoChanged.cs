using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZayProject.Migrations
{
    /// <inheritdoc />
    public partial class PhotoChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Products",
                newName: "Photo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Products",
                newName: "PhotoPath");
        }
    }
}
