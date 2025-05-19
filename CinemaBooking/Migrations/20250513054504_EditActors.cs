using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    /// <inheritdoc />
    public partial class EditActors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "ActorsId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    News = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    moviesId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_images_Movie_moviesId",
                        column: x => x.moviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "actorMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    moviesId = table.Column<int>(type: "int", nullable: false),
                    actorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actorMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_actorMovies_Movie_moviesId",
                        column: x => x.moviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_actorMovies_actors_actorsId",
                        column: x => x.actorsId,
                        principalTable: "actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ActorsId",
                table: "Movie",
                column: "ActorsId");

            migrationBuilder.CreateIndex(
                name: "IX_actorMovies_actorsId",
                table: "actorMovies",
                column: "actorsId");

            migrationBuilder.CreateIndex(
                name: "IX_actorMovies_moviesId",
                table: "actorMovies",
                column: "moviesId");

            migrationBuilder.CreateIndex(
                name: "IX_images_moviesId",
                table: "images",
                column: "moviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_actors_ActorsId",
                table: "Movie",
                column: "ActorsId",
                principalTable: "actors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_actors_ActorsId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "actorMovies");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "actors");

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
    }
}
