using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityLifeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateStatusIdBedRoomRoomType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BedRoomRoomStatusId",
                table: "BedRoomRoomTypes",
                newName: "BedRoomRoomTypeStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BedRoomRoomTypeStatusId",
                table: "BedRoomRoomTypes",
                newName: "BedRoomRoomStatusId");
        }
    }
}
