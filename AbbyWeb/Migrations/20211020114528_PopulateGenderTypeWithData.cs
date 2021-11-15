using Microsoft.EntityFrameworkCore.Migrations;

namespace AbbyWeb.Migrations
{
    public partial class PopulateGenderTypeWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genders(Name,Description) Values('Male', 'Gender of a Male.')");

            migrationBuilder.Sql("INSERT INTO Genders(Name,Description) Values('Female', 'Gender of a Female.')");

            migrationBuilder.Sql("INSERT INTO Genders(Name,Description) Values('Other', 'Gender of a Other.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
