using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityLifeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAppliedToBedRoomRoomApplied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Applied",
                table: "BedRoomRoomApplies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Applied",
                table: "BedRoomRoomApplies",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
