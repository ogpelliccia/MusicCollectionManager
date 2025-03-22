﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicCollectionManager.Data;

#nullable disable

namespace MusicCollectionManagerSQLite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250322053434_initialcreate")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("MusicCollectionManager.Models.Album", b =>
                {
                    b.Property<int>("AlbumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ArtistID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NumOfSongs")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecordLabel")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TotalDuration")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlbumID");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("MusicCollectionManager.Models.Band", b =>
                {
                    b.Property<int>("BandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BandName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("YearDisbanded")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("YearFormed")
                        .HasColumnType("INTEGER");

                    b.HasKey("BandID");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("MusicCollectionManager.Models.Credit", b =>
                {
                    b.Property<int>("CreditID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreditType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MusicianID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CreditID");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("MusicCollectionManager.Models.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MusicCollectionManager.Models.GroupLinking", b =>
                {
                    b.Property<int>("LinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupID")
                        .HasColumnType("INTEGER");

                    b.HasKey("LinkID");

                    b.ToTable("GroupLinkings");
                });

            modelBuilder.Entity("MusicCollectionManager.Models.Musician", b =>
                {
                    b.Property<int>("MusicianID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ethnicity")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Hometown")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimaryOccupation")
                        .HasColumnType("TEXT");

                    b.HasKey("MusicianID");

                    b.ToTable("Musicians");
                });

            modelBuilder.Entity("MusicCollectionManager.Models.RecordingArtist", b =>
                {
                    b.Property<int>("ArtistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BandID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MusicianID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StageName")
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistID");

                    b.ToTable("RecordingArtists");
                });

            modelBuilder.Entity("MusicCollectionManager.Models.Song", b =>
                {
                    b.Property<int>("SongID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("BPM")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Favorite")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NumOfListens")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Vocals")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SongID");

                    b.ToTable("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
