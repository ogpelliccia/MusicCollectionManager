using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicCollectionManagerSQLite.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlbumName = table.Column<string>(type: "TEXT", nullable: false),
                    ArtistID = table.Column<int>(type: "INTEGER", nullable: true),
                    GroupID = table.Column<int>(type: "INTEGER", nullable: true),
                    RecordLabel = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: true),
                    NumOfSongs = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalDuration = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumID);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    BandID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupID = table.Column<int>(type: "INTEGER", nullable: false),
                    BandName = table.Column<string>(type: "TEXT", nullable: false),
                    YearFormed = table.Column<int>(type: "INTEGER", nullable: true),
                    YearDisbanded = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.BandID);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    CreditID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MusicianID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreditType = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.CreditID);
                });

            migrationBuilder.CreateTable(
                name: "GroupLinkings",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtistID = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLinkings", x => x.LinkID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    MusicianID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Hometown = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Ethnicity = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryOccupation = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.MusicianID);
                });

            migrationBuilder.CreateTable(
                name: "RecordingArtists",
                columns: table => new
                {
                    ArtistID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MusicianID = table.Column<int>(type: "INTEGER", nullable: true),
                    GroupID = table.Column<int>(type: "INTEGER", nullable: true),
                    StageName = table.Column<string>(type: "TEXT", nullable: true),
                    BandID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordingArtists", x => x.ArtistID);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    ArtistID = table.Column<int>(type: "INTEGER", nullable: false),
                    AlbumID = table.Column<int>(type: "INTEGER", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    BPM = table.Column<double>(type: "REAL", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    NumOfListens = table.Column<int>(type: "INTEGER", nullable: true),
                    Vocals = table.Column<string>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Favorite = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "GroupLinkings");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "RecordingArtists");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
