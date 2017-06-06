using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectCinderella.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artist = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    CheckedOut = table.Column<bool>(nullable: false),
                    CompletionStatus = table.Column<int>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: true),
                    CountryPurchased = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false),
                    DatePurchased = table.Column<DateTime>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DiscogsID = table.Column<int>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsNew = table.Column<bool>(nullable: false),
                    IsPhysical = table.Column<bool>(nullable: false),
                    IsQueued = table.Column<bool>(nullable: false),
                    IsShowcased = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    LocationPurchased = table.Column<string>(nullable: true),
                    MediaType = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    QueueRank = table.Column<int>(nullable: false),
                    RecordLabel = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Style = table.Column<string>(nullable: true),
                    TimesCompleted = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    UserNum = table.Column<int>(nullable: false),
                    YearReleased = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    CheckedOut = table.Column<bool>(nullable: false),
                    CompletionStatus = table.Column<int>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: true),
                    CountryPurchased = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false),
                    DatePurchased = table.Column<DateTime>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    GoogleBookID = table.Column<string>(nullable: true),
                    Hardcover = table.Column<bool>(nullable: false),
                    ISBN10 = table.Column<string>(nullable: true),
                    ISBN13 = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsFirstEdition = table.Column<bool>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    IsPhysical = table.Column<bool>(nullable: false),
                    IsQueued = table.Column<bool>(nullable: false),
                    IsReissue = table.Column<bool>(nullable: false),
                    IsShowcased = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    LocationPurchased = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PageCount = table.Column<int>(nullable: false),
                    Publisher = table.Column<string>(nullable: false),
                    QueueRank = table.Column<int>(nullable: false),
                    TimesCompleted = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    UserNum = table.Column<int>(nullable: false),
                    YearReleased = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pop",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true),
                    CheckedOut = table.Column<bool>(nullable: false),
                    CompletionStatus = table.Column<int>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: true),
                    CountryPurchased = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false),
                    DatePurchased = table.Column<DateTime>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsNew = table.Column<bool>(nullable: false),
                    IsPhysical = table.Column<bool>(nullable: false),
                    IsQueued = table.Column<bool>(nullable: false),
                    IsShowcased = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    LocationPurchased = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    PopLine = table.Column<string>(nullable: false),
                    QueueRank = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: false),
                    TimesCompleted = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    UserNum = table.Column<int>(nullable: false),
                    YearReleased = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pop", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BGGID = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    CheckedOut = table.Column<bool>(nullable: false),
                    CompletionStatus = table.Column<int>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: true),
                    CountryPurchased = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false),
                    DatePurchased = table.Column<DateTime>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Developer = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    GiantBombID = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsDLC = table.Column<bool>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    IsPhysical = table.Column<bool>(nullable: false),
                    IsQueued = table.Column<bool>(nullable: false),
                    IsShowcased = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    LocationPurchased = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PartOfSeries = table.Column<bool>(nullable: false),
                    Platform = table.Column<int>(nullable: false),
                    Publisher = table.Column<string>(nullable: false),
                    QueueRank = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true),
                    TimesCompleted = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    UserNum = table.Column<int>(nullable: false),
                    YearReleased = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true),
                    CheckedOut = table.Column<bool>(nullable: false),
                    CompletionStatus = table.Column<int>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: true),
                    CountryPurchased = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false),
                    DatePurchased = table.Column<DateTime>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Distributor = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsNew = table.Column<bool>(nullable: false),
                    IsPhysical = table.Column<bool>(nullable: false),
                    IsQueued = table.Column<bool>(nullable: false),
                    IsShowcased = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    LocationPurchased = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    QueueRank = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    SeasonNumber = table.Column<int>(nullable: false),
                    TMDBID = table.Column<int>(nullable: false),
                    TimesCompleted = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    UserNum = table.Column<int>(nullable: false),
                    YearReleased = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wish",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApiID = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ItemType = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Owned = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wish", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tracklist",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlbumID = table.Column<int>(nullable: false),
                    duration = table.Column<string>(nullable: true),
                    position = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracklist", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tracklist_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracklist_AlbumID",
                table: "Tracklist",
                column: "AlbumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Pop");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Wish");

            migrationBuilder.DropTable(
                name: "Tracklist");

            migrationBuilder.DropTable(
                name: "Album");
        }
    }
}
