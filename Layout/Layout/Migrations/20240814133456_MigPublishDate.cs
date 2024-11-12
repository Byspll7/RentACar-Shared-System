using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Layout.Migrations
{
    /// <inheritdoc />
    public partial class MigPublishDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "TblProduct",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "TblProduct");
        }
    }
}
