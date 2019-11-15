using Microsoft.EntityFrameworkCore.Migrations;

namespace WetaherFinder.ConsoleApp.Migrations
{
    public partial class AdddCityForForecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Forecasts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Forecasts");
        }
    }
}
