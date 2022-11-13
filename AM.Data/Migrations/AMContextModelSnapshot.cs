﻿// <auto-generated />
using System;
using AM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Data.Migrations
{
    [DbContext(typeof(AMContext))]
    partial class AMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AM.Core.Domain.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"), 1L, 1);

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveArrival")
                        .HasColumnType("date");

                    b.Property<int>("EstimatedDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("date");

                    b.Property<int?>("PlaneId")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AM.Core.Domain.Passenger", b =>
                {
                    b.Property<string>("PassportNumber")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassportNumber");

                    b.ToTable("Passengers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Passenger");
                });

            modelBuilder.Entity("AM.Core.Domain.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneId"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("PlaneCapacity");

                    b.Property<DateTime>("ManifactureDate")
                        .HasColumnType("date");

                    b.Property<int>("MyPlaneType")
                        .HasColumnType("int");

                    b.HasKey("PlaneId");

                    b.ToTable("MyPlanes", (string)null);
                });

            modelBuilder.Entity("AM.Core.Domain.Reservation", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"), 1L, 1);

                    b.Property<int>("MyFlightFlightId")
                        .HasColumnType("int");

                    b.Property<string>("PassengerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(7)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Seat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VIP")
                        .HasColumnType("bit");

                    b.HasKey("FlightId");

                    b.HasIndex("MyFlightFlightId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.Property<int>("FlightsFlightId")
                        .HasColumnType("int");

                    b.Property<string>("PassengersPassportNumber")
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("FlightsFlightId", "PassengersPassportNumber");

                    b.HasIndex("PassengersPassportNumber");

                    b.ToTable("PassFlight", (string)null);
                });

            modelBuilder.Entity("AM.Core.Domain.Staff", b =>
                {
                    b.HasBaseType("AM.Core.Domain.Passenger");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("date");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Staff");
                });

            modelBuilder.Entity("AM.Core.Domain.Traveller", b =>
                {
                    b.HasBaseType("AM.Core.Domain.Passenger");

                    b.Property<string>("HealthInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Traveller");
                });

            modelBuilder.Entity("AM.Core.Domain.Flight", b =>
                {
                    b.HasOne("AM.Core.Domain.Plane", "MyPlane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("MyPlane");
                });

            modelBuilder.Entity("AM.Core.Domain.Passenger", b =>
                {
                    b.OwnsOne("AM.Core.Domain.FullName", "MyFullName", b1 =>
                        {
                            b1.Property<string>("PassengerPassportNumber")
                                .HasColumnType("nvarchar(7)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)")
                                .HasColumnName("Name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PassengerPassportNumber");

                            b1.ToTable("Passengers");

                            b1.WithOwner()
                                .HasForeignKey("PassengerPassportNumber");
                        });

                    b.Navigation("MyFullName")
                        .IsRequired();
                });

            modelBuilder.Entity("AM.Core.Domain.Reservation", b =>
                {
                    b.HasOne("AM.Core.Domain.Flight", "MyFlight")
                        .WithMany("Reservations")
                        .HasForeignKey("MyFlightFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.Core.Domain.Passenger", "MyPassenger")
                        .WithMany("Reservations")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyFlight");

                    b.Navigation("MyPassenger");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.HasOne("AM.Core.Domain.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightsFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.Core.Domain.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengersPassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.Core.Domain.Flight", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AM.Core.Domain.Passenger", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AM.Core.Domain.Plane", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
