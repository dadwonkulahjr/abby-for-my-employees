using Microsoft.EntityFrameworkCore.Migrations;

namespace AbbyWeb.Migrations
{
    public partial class PopulateOccupationWithInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Occupations(Name,Decription) Values('Programmer', 'Computer Programmer')");

            migrationBuilder.Sql("INSERT INTO Occupations(Name,Decription) Values('Software Developer', 'Design and write computer programs')");

            migrationBuilder.Sql("INSERT INTO Occupations(Name,Decription) Values('Agent', 'Bring in customers for the company')");

            migrationBuilder.Sql("INSERT INTO Occupations(Name,Decription) Values('CEO', 'The chief executive officer of the company')");

            migrationBuilder.Sql("INSERT INTO Occupations(Name,Decription) Values('Finance Director', 'Control and manage all the money in the company')");

            migrationBuilder.Sql("INSERT INTO Occupations(Name,Decription) Values('Human Resource', 'Responsible for taking care of employees compensation')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
