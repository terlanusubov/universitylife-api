using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityLifeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsTopToCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTop",
                table: "Cities",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTop",
                table: "Cities");
        }
    }
}
