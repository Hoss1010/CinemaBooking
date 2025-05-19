using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    /// <inheritdoc />
    public partial class EditMov : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_actors_ActorsId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ActorsId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ActorsId",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "ActorsId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ActorsId",
                table: "Movie",
                column: "ActorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_actors_ActorsId",
                table: "Movie",
                column: "ActorsId",
                principalTable: "actors",
                principalColumn: "Id");
        }
    }
}
