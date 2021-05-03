using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDatabase.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreSong_Artists_ArtistId",
                table: "GenreSong");

            migrationBuilder.DropIndex(
                name: "IX_GenreSong_ArtistId",
                table: "GenreSong");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "GenreSong");

            migrationBuilder.RenameColumn(
                name: "GenretId",
                table: "Songs",
                newName: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Songs",
                newName: "GenretId");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "GenreSong",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_ArtistId",
                table: "GenreSong",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreSong_Artists_ArtistId",
                table: "GenreSong",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
