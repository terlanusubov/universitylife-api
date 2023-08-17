using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityLifeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Cities",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Cities");
        }
    }
}
