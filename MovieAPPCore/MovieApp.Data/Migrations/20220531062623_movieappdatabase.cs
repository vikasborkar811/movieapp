using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class movieappdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThetreName",
                table: "theatreModels",
                newName: "TheatreName");

            migrationBuilder.RenameColumn(
                name: "ThetreLocation",
                table: "theatreModels",
                newName: "TheatreLocation");

            migrationBuilder.RenameColumn(
                name: "ThetreCapacity",
                table: "theatreModels",
                newName: "TheatreCapacity");

            migrationBuilder.RenameColumn(
                name: "ThetreId",
                table: "theatreModels",
                newName: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TheatreName",
                table: "theatreModels",
                newName: "ThetreName");

            migrationBuilder.RenameColumn(
                name: "TheatreLocation",
                table: "theatreModels",
                newName: "ThetreLocation");

            migrationBuilder.RenameColumn(
                name: "TheatreCapacity",
                table: "theatreModels",
                newName: "ThetreCapacity");

            migrationBuilder.RenameColumn(
                name: "TheatreId",
                table: "theatreModels",
                newName: "ThetreId");
        }
    }
}
