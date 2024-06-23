using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RodaVelha.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Events");
        }
    }
}
