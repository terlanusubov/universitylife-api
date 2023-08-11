using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityLifeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusIdToUniversity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UniversityStatusId",
                table: "Universities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniversityStatusId",
                table: "Universities");
        }
    }
}
