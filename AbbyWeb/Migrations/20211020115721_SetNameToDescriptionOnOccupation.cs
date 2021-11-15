using Microsoft.EntityFrameworkCore.Migrations;

namespace AbbyWeb.Migrations
{
    public partial class SetNameToDescriptionOnOccupation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decription",
                table: "Occupations",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Occupations",
                newName: "Decription");
        }
    }
}
