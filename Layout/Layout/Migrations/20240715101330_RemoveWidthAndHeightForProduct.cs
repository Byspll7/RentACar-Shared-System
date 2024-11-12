using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Layout.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWidthAndHeightForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "TblProduct");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "TblProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "TblProduct",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "TblProduct",
                type: "int",
                nullable: true);
        }
    }
}
