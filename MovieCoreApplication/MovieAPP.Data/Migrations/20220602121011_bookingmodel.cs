using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class bookingmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookingModels",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingModels", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_bookingModels_movieModels_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModels",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookingModels_theatreModels_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theatreModels",
                        principalColumn: "TheatreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookingModels_userModels_UserId",
                        column: x => x.UserId,
                        principalTable: "userModels",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingModels_MovieId",
                table: "bookingModels",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingModels_TheatreId",
                table: "bookingModels",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingModels_UserId",
                table: "bookingModels",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingModels");
        }
    }
}
