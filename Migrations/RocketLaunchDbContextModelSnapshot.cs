﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rocket_Launch_Database__2_.Data;

#nullable disable

namespace Rocket_Launch_Database__2_.Migrations
{
    [DbContext(typeof(RocketLaunchDbContext))]
    partial class RocketLaunchDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Rocket_Launch_Database__2_.Models.LaunchSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LaunchSites");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "USA",
                            Name = "Site A"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Russia",
                            Name = "Site B"
                        });
                });

            modelBuilder.Entity("Rocket_Launch_Database__2_.Models.LaunchVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LaunchVehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Manufacturer = "SpaceX",
                            Name = "Falcon 9"
                        },
                        new
                        {
                            Id = 2,
                            Manufacturer = "Roscosmos",
                            Name = "Soyuz"
                        });
                });

            modelBuilder.Entity("Rocket_Launch_Database__2_.Models.Payload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Payloads");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Payload A",
                            Type = "Satellite",
                            Weight = 1000f
                        },
                        new
                        {
                            Id = 2,
                            Name = "Payload B",
                            Type = "Spacecraft",
                            Weight = 2000f
                        });
                });

            modelBuilder.Entity("Rocket_Launch_Database__2_.Models.RocketLaunch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LaunchDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LaunchSiteId")
                        .HasColumnType("int");

                    b.Property<int>("LaunchVehicleId")
                        .HasColumnType("int");

                    b.Property<string>("MissionOutcome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PayloadId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LaunchSiteId");

                    b.HasIndex("LaunchVehicleId");

                    b.HasIndex("PayloadId");

                    b.HasIndex("UserId");

                    b.ToTable("RocketLaunches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LaunchDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LaunchSiteId = 1,
                            LaunchVehicleId = 1,
                            MissionOutcome = "Success",
                            PayloadId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            LaunchDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LaunchSiteId = 2,
                            LaunchVehicleId = 2,
                            MissionOutcome = "Failure",
                            PayloadId = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Rocket_Launch_Database__2_.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "alice@example.com",
                            Name = "Alice"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bob@example.com",
                            Name = "Bob"
                        });
                });

            modelBuilder.Entity("Rocket_Launch_Database__2_.Models.RocketLaunch", b =>
                {
                    b.HasOne("Rocket_Launch_Database__2_.Models.LaunchSite", "LaunchSite")
                        .WithMany()
                        .HasForeignKey("LaunchSiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rocket_Launch_Database__2_.Models.LaunchVehicle", "LaunchVehicle")
                        .WithMany()
                        .HasForeignKey("LaunchVehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rocket_Launch_Database__2_.Models.Payload", "Payload")
                        .WithMany()
                        .HasForeignKey("PayloadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rocket_Launch_Database__2_.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LaunchSite");

                    b.Navigation("LaunchVehicle");

                    b.Navigation("Payload");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
