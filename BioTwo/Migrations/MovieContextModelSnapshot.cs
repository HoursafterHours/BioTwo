﻿using System;
using BioTwo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BioTwo.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BioTwo.Models.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingID"));

                    b.Property<string>("BookingNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int>("ShowingID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("ShowingID");

                    b.ToTable("Booking", (string)null);
                });

            modelBuilder.Entity("BioTwo.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieID");

                    b.ToTable("Movie", (string)null);
                });

            modelBuilder.Entity("BioTwo.Models.Salon", b =>
                {
                    b.Property<int>("SalonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalonID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatCount")
                        .HasColumnType("int");

                    b.Property<int>("SeatPerRow")
                        .HasColumnType("int");

                    b.HasKey("SalonID");

                    b.ToTable("Salon", (string)null);
                });

            modelBuilder.Entity("BioTwo.Models.Showing", b =>
                {
                    b.Property<int>("ShowingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowingID"));

                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<int>("SalonID")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("ShowingTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ShowingID");

                    b.HasIndex("MovieID");

                    b.HasIndex("SalonID");

                    b.ToTable("Showing", (string)null);
                });

            modelBuilder.Entity("BioTwo.Models.Booking", b =>
                {
                    b.HasOne("BioTwo.Models.Showing", "Showing")
                        .WithMany()
                        .HasForeignKey("ShowingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Showing");
                });

            modelBuilder.Entity("BioTwo.Models.Showing", b =>
                {
                    b.HasOne("BioTwo.Models.Movie", "Movie")
                        .WithMany("Showings")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioTwo.Models.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("BioTwo.Models.Movie", b =>
                {
                    b.Navigation("Showings");
                });
#pragma warning restore 612, 618
        }
    }
}
