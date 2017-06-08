﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectCinderella.Data.DAL;
using ProjectCinderella.Model.Enums;
using System;

namespace ProjectCinderella.Data.Migrations
{
    [DbContext(typeof(ProjectCinderellaContext))]
    partial class ProjectCinderellaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview1-24937")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectCinderella.Model.Common.Album", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artist")
                        .IsRequired();

                    b.Property<string>("Category");

                    b.Property<bool>("CheckedOut");

                    b.Property<int>("CompletionStatus");

                    b.Property<string>("CountryOfOrigin");

                    b.Property<string>("CountryPurchased");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateCompleted");

                    b.Property<DateTime>("DatePurchased");

                    b.Property<DateTime>("DateStarted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int>("DiscogsID");

                    b.Property<string>("Genre");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsNew");

                    b.Property<bool>("IsPhysical");

                    b.Property<bool>("IsQueued");

                    b.Property<bool>("IsShowcased");

                    b.Property<string>("Language");

                    b.Property<string>("LocationPurchased");

                    b.Property<int>("MediaType");

                    b.Property<string>("Notes");

                    b.Property<int>("QueueRank");

                    b.Property<string>("RecordLabel");

                    b.Property<int>("Size");

                    b.Property<int>("Speed");

                    b.Property<string>("Style");

                    b.Property<int>("TimesCompleted");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.Property<int>("UserNum");

                    b.Property<int>("YearReleased");

                    b.HasKey("ID");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("ProjectCinderella.Model.Common.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Category");

                    b.Property<bool>("CheckedOut");

                    b.Property<int>("CompletionStatus");

                    b.Property<string>("CountryOfOrigin");

                    b.Property<string>("CountryPurchased");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateCompleted");

                    b.Property<DateTime>("DatePurchased");

                    b.Property<DateTime>("DateStarted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Genre");

                    b.Property<string>("GoogleBookID");

                    b.Property<bool>("Hardcover");

                    b.Property<string>("ISBN10");

                    b.Property<string>("ISBN13");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsFirstEdition");

                    b.Property<bool>("IsNew");

                    b.Property<bool>("IsPhysical");

                    b.Property<bool>("IsQueued");

                    b.Property<bool>("IsReissue");

                    b.Property<bool>("IsShowcased");

                    b.Property<string>("Language");

                    b.Property<string>("LocationPurchased");

                    b.Property<string>("Notes");

                    b.Property<int>("PageCount");

                    b.Property<string>("Publisher")
                        .IsRequired();

                    b.Property<int>("QueueRank");

                    b.Property<int>("TimesCompleted");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.Property<int>("UserNum");

                    b.Property<int>("YearReleased");

                    b.HasKey("ID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("ProjectCinderella.Model.Common.FunkoModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<bool>("CheckedOut");

                    b.Property<int>("CompletionStatus");

                    b.Property<string>("CountryOfOrigin");

                    b.Property<string>("CountryPurchased");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateCompleted");

                    b.Property<DateTime>("DatePurchased");

                    b.Property<DateTime>("DateStarted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Genre");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsNew");

                    b.Property<bool>("IsPhysical");

                    b.Property<bool>("IsQueued");

                    b.Property<bool>("IsShowcased");

                    b.Property<string>("Language");

                    b.Property<string>("LocationPurchased");

                    b.Property<string>("Notes");

                    b.Property<int>("Number");

                    b.Property<string>("PopLine")
                        .IsRequired();

                    b.Property<int>("QueueRank");

                    b.Property<string>("Series")
                        .IsRequired();

                    b.Property<int>("TimesCompleted");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.Property<int>("UserNum");

                    b.Property<int>("YearReleased");

                    b.HasKey("ID");

                    b.ToTable("Pop");
                });

            modelBuilder.Entity("ProjectCinderella.Model.Common.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BGGID");

                    b.Property<string>("Category");

                    b.Property<bool>("CheckedOut");

                    b.Property<int>("CompletionStatus");

                    b.Property<string>("CountryOfOrigin");

                    b.Property<string>("CountryPurchased");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateCompleted");

                    b.Property<DateTime>("DatePurchased");

                    b.Property<DateTime>("DateStarted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Developer")
                        .IsRequired();

                    b.Property<string>("Genre");

                    b.Property<int>("GiantBombID");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsDLC");

                    b.Property<bool>("IsNew");

                    b.Property<bool>("IsPhysical");

                    b.Property<bool>("IsQueued");

                    b.Property<bool>("IsShowcased");

                    b.Property<string>("Language");

                    b.Property<string>("LocationPurchased");

                    b.Property<string>("Notes");

                    b.Property<bool>("PartOfSeries");

                    b.Property<int>("Platform");

                    b.Property<string>("Publisher")
                        .IsRequired();

                    b.Property<int>("QueueRank");

                    b.Property<int>("Rating");

                    b.Property<string>("Series");

                    b.Property<int>("TimesCompleted");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.Property<int>("UserNum");

                    b.Property<int>("YearReleased");

                    b.HasKey("ID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("ProjectCinderella.Model.Common.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<bool>("CheckedOut");

                    b.Property<int>("CompletionStatus");

                    b.Property<string>("CountryOfOrigin");

                    b.Property<string>("CountryPurchased");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateCompleted");

                    b.Property<DateTime>("DatePurchased");

                    b.Property<DateTime>("DateStarted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Director")
                        .IsRequired();

                    b.Property<string>("Distributor");

                    b.Property<string>("Genre");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsNew");

                    b.Property<bool>("IsPhysical");

                    b.Property<bool>("IsQueued");

                    b.Property<bool>("IsShowcased");

                    b.Property<string>("Language");

                    b.Property<string>("LocationPurchased");

                    b.Property<string>("Notes");

                    b.Property<int>("QueueRank");

                    b.Property<int>("Rating");

                    b.Property<int>("SeasonNumber");

                    b.Property<int>("TMDBID");

                    b.Property<int>("TimesCompleted");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.Property<int>("UserNum");

                    b.Property<int>("YearReleased");

                    b.HasKey("ID");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("ProjectCinderella.Model.Common.Wish", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApiID");

                    b.Property<string>("Category");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("ItemType");

                    b.Property<string>("Notes");

                    b.Property<bool>("Owned");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Wish");
                });

            modelBuilder.Entity("ProjectCinderella.Model.DiscogsModels.Tracklist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumID");

                    b.Property<string>("duration");

                    b.Property<string>("position");

                    b.Property<string>("title");

                    b.HasKey("ID");

                    b.HasIndex("AlbumID");

                    b.ToTable("Tracklist");
                });

            modelBuilder.Entity("ProjectCinderella.Model.DiscogsModels.Tracklist", b =>
                {
                    b.HasOne("ProjectCinderella.Model.Common.Album")
                        .WithMany("Tracklist")
                        .HasForeignKey("AlbumID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}