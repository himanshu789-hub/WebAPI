﻿// <auto-generated />
using System;
using CarPoolAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarPoolAPI.Migrations
{
    [DbContext(typeof(CarPoolContext))]
    [Migration("20200216130227_Migrations")]
    partial class Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarPoolAPI.Models.Anounce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("BookingRef")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnName("Source")
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingRef")
                        .IsUnique()
                        .HasFilter("[BookingRef] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Anounces");
                });

            modelBuilder.Entity("CarPoolAPI.Models.AnounceOfferring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnounceId")
                        .HasColumnType("int");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("AnounceId");

                    b.HasIndex("OfferId");

                    b.ToTable("AnounceOfferrings");
                });

            modelBuilder.Entity("CarPoolAPI.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AnounceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookingStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("FarePrice")
                        .HasColumnType("real");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<string>("RequestedDestination")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("RequestedSource")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("SeatsBooked")
                        .HasColumnType("int");

                    b.Property<string>("Soure")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CarPoolAPI.Models.Offerring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CurrentLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("DepartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Discount")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("MaxOfferSeats")
                        .HasColumnType("int");

                    b.Property<float>("PricePerKM")
                        .HasColumnType("real");

                    b.Property<int>("SeatsAvail")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TentativeTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("TotalEarning")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VechicleRef")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VechicleRef")
                        .IsUnique();

                    b.ToTable("Offerrings");
                });

            modelBuilder.Entity("CarPoolAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 3301,
                            Age = 20,
                            Gender = "MALE",
                            Name = "Monu",
                            Password = "monu"
                        },
                        new
                        {
                            Id = 3302,
                            Age = 22,
                            Gender = "MALE",
                            Name = "Abhinav",
                            Password = "abhinav"
                        },
                        new
                        {
                            Id = 3306,
                            Age = 24,
                            Gender = "MALE",
                            Name = "Sreyash",
                            Password = "sreyash"
                        },
                        new
                        {
                            Id = 3305,
                            Age = 21,
                            Gender = "FEMALE",
                            Name = "Priya",
                            Password = "priya"
                        },
                        new
                        {
                            Id = 3308,
                            Age = 24,
                            Gender = "MALE",
                            Name = "Devansh",
                            Password = "devansh"
                        });
                });

            modelBuilder.Entity("CarPoolAPI.Models.Vechicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("NumberPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Vechicles");
                });

            modelBuilder.Entity("CarPoolAPI.Models.ViaPoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.ToTable("ViaPoints");
                });

            modelBuilder.Entity("CarPoolAPI.Models.Anounce", b =>
                {
                    b.HasOne("CarPoolAPI.Models.Booking", "Booking")
                        .WithOne("Anounce")
                        .HasForeignKey("CarPoolAPI.Models.Anounce", "BookingRef");

                    b.HasOne("CarPoolAPI.Models.User", "User")
                        .WithMany("Announces")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarPoolAPI.Models.AnounceOfferring", b =>
                {
                    b.HasOne("CarPoolAPI.Models.Anounce", "Anounce")
                        .WithMany("AnnounceOfferrings")
                        .HasForeignKey("AnounceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPoolAPI.Models.Offerring", "Offerring")
                        .WithMany("AnnounceOfferrings")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarPoolAPI.Models.Booking", b =>
                {
                    b.HasOne("CarPoolAPI.Models.Offerring", "Offerring")
                        .WithMany("Bookings")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPoolAPI.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarPoolAPI.Models.Offerring", b =>
                {
                    b.HasOne("CarPoolAPI.Models.User", "User")
                        .WithMany("Offerrings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPoolAPI.Models.Vechicles", "Vechicles")
                        .WithOne("Offerring")
                        .HasForeignKey("CarPoolAPI.Models.Offerring", "VechicleRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarPoolAPI.Models.ViaPoints", b =>
                {
                    b.HasOne("CarPoolAPI.Models.Offerring", "Offerring")
                        .WithMany("ViaPoints")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
