﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservio.AppDataContext;

#nullable disable

namespace Reservio.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240116221743_Rename_DayOfWeek_Day")]
    partial class Rename_DayOfWeek_Day
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Reservio.Models.Clinic", b =>
                {
                    b.Property<int>("ClinicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClinicId"));

                    b.Property<int>("AcceptedPatientsCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClinicId");

                    b.ToTable("Clinics");

                    b.HasData(
                        new
                        {
                            ClinicId = 1,
                            AcceptedPatientsCount = 10,
                            IsDeleted = false,
                            Name = "Heart Clinic"
                        },
                        new
                        {
                            ClinicId = 2,
                            AcceptedPatientsCount = 5,
                            IsDeleted = false,
                            Name = "Children's Clinic"
                        },
                        new
                        {
                            ClinicId = 3,
                            AcceptedPatientsCount = 8,
                            IsDeleted = false,
                            Name = "Eye Clinic"
                        },
                        new
                        {
                            ClinicId = 4,
                            AcceptedPatientsCount = 12,
                            IsDeleted = false,
                            Name = "Ear, Nose and Throat Clinic"
                        },
                        new
                        {
                            ClinicId = 5,
                            AcceptedPatientsCount = 15,
                            IsDeleted = false,
                            Name = "Dermatology Clinic"
                        });
                });

            modelBuilder.Entity("Reservio.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Specialist")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            FullName = "Dr. Smith",
                            IsDeleted = false,
                            Specialist = "Cardiology"
                        },
                        new
                        {
                            DoctorId = 2,
                            FullName = "Dr. Johnson",
                            IsDeleted = false,
                            Specialist = "Cardiology"
                        },
                        new
                        {
                            DoctorId = 3,
                            FullName = "Dr. Williams",
                            IsDeleted = false,
                            Specialist = "Pediatrics"
                        },
                        new
                        {
                            DoctorId = 4,
                            FullName = "Dr. Brown",
                            IsDeleted = false,
                            Specialist = "Pediatrics"
                        },
                        new
                        {
                            DoctorId = 5,
                            FullName = "Dr. Jones",
                            IsDeleted = false,
                            Specialist = "Ophthalmology"
                        },
                        new
                        {
                            DoctorId = 6,
                            FullName = "Dr. Davis",
                            IsDeleted = false,
                            Specialist = "Ophthalmology"
                        },
                        new
                        {
                            DoctorId = 7,
                            FullName = "Dr. Miller",
                            IsDeleted = false,
                            Specialist = "ENT"
                        },
                        new
                        {
                            DoctorId = 8,
                            FullName = "Dr. Wilson",
                            IsDeleted = false,
                            Specialist = "ENT"
                        },
                        new
                        {
                            DoctorId = 9,
                            FullName = "Dr. Moore",
                            IsDeleted = false,
                            Specialist = "Dermatology"
                        },
                        new
                        {
                            DoctorId = 10,
                            FullName = "Dr. Taylor",
                            IsDeleted = false,
                            Specialist = "Dermatology"
                        });
                });

            modelBuilder.Entity("Reservio.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Resgoin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Reservio.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<DateTime>("BookFor")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Resgoin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("PatientId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            BookFor = new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc),
                            ClinicId = 1,
                            Date = new DateTime(2024, 1, 17, 6, 17, 42, 976, DateTimeKind.Local).AddTicks(6241),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Abdullah",
                            Gender = 1,
                            IPAddress = "192.168.0.1",
                            IsDeleted = false,
                            LastName = "Doe",
                            PhoneNumber = "1234567890",
                            Resgoin = "Reason for reservation 1"
                        },
                        new
                        {
                            ReservationId = 2,
                            BookFor = new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc),
                            ClinicId = 2,
                            Date = new DateTime(2024, 1, 17, 8, 17, 42, 976, DateTimeKind.Local).AddTicks(6279),
                            DateOfBirth = new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Omar",
                            Gender = 2,
                            IPAddress = "192.168.0.2",
                            IsDeleted = false,
                            LastName = "Doe",
                            PhoneNumber = "9876543210",
                            Resgoin = "Reason for reservation 2"
                        },
                        new
                        {
                            ReservationId = 3,
                            BookFor = new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc),
                            ClinicId = 3,
                            Date = new DateTime(2024, 1, 17, 5, 17, 42, 976, DateTimeKind.Local).AddTicks(6285),
                            DateOfBirth = new DateTime(1982, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Saad",
                            Gender = 2,
                            IPAddress = "192.168.0.3",
                            IsDeleted = false,
                            LastName = "Smith",
                            PhoneNumber = "5551234567",
                            Resgoin = "Reason for reservation 3"
                        },
                        new
                        {
                            ReservationId = 4,
                            BookFor = new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc),
                            ClinicId = 4,
                            Date = new DateTime(2024, 1, 17, 11, 17, 42, 976, DateTimeKind.Local).AddTicks(6292),
                            DateOfBirth = new DateTime(1975, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ammar",
                            Gender = 1,
                            IPAddress = "192.168.0.4",
                            IsDeleted = false,
                            LastName = "Johnson",
                            PhoneNumber = "3339876543",
                            Resgoin = "Reason for reservation 4"
                        },
                        new
                        {
                            ReservationId = 5,
                            BookFor = new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc),
                            ClinicId = 5,
                            Date = new DateTime(2024, 1, 17, 2, 17, 42, 976, DateTimeKind.Local).AddTicks(6299),
                            DateOfBirth = new DateTime(1988, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ali",
                            Gender = 2,
                            IPAddress = "192.168.0.5",
                            IsDeleted = false,
                            LastName = "Anderson",
                            PhoneNumber = "1112223333",
                            Resgoin = "Reason for reservation 5"
                        },
                        new
                        {
                            ReservationId = 6,
                            BookFor = new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc),
                            ClinicId = 1,
                            Date = new DateTime(2024, 1, 17, 11, 17, 42, 976, DateTimeKind.Local).AddTicks(6307),
                            DateOfBirth = new DateTime(1978, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Michael",
                            Gender = 1,
                            IPAddress = "192.168.0.6",
                            IsDeleted = false,
                            LastName = "Clark",
                            PhoneNumber = "9998887777",
                            Resgoin = "Reason for reservation 6"
                        },
                        new
                        {
                            ReservationId = 7,
                            BookFor = new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc),
                            ClinicId = 3,
                            Date = new DateTime(2024, 1, 17, 3, 17, 42, 976, DateTimeKind.Local).AddTicks(6313),
                            DateOfBirth = new DateTime(1995, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sophia",
                            Gender = 2,
                            IPAddress = "192.168.0.7",
                            IsDeleted = false,
                            LastName = "Brown",
                            PhoneNumber = "7775558888",
                            Resgoin = "Reason for reservation 7"
                        });
                });

            modelBuilder.Entity("Reservio.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ScheduleId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            ScheduleId = 1,
                            ClinicId = 1,
                            Day = 1,
                            DoctorId = 1,
                            IsDeleted = false
                        },
                        new
                        {
                            ScheduleId = 2,
                            ClinicId = 1,
                            Day = 2,
                            DoctorId = 2,
                            IsDeleted = false
                        },
                        new
                        {
                            ScheduleId = 3,
                            ClinicId = 2,
                            Day = 3,
                            DoctorId = 3,
                            IsDeleted = false
                        },
                        new
                        {
                            ScheduleId = 4,
                            ClinicId = 3,
                            Day = 4,
                            DoctorId = 4,
                            IsDeleted = false
                        },
                        new
                        {
                            ScheduleId = 5,
                            ClinicId = 3,
                            Day = 5,
                            DoctorId = 5,
                            IsDeleted = false
                        },
                        new
                        {
                            ScheduleId = 6,
                            ClinicId = 4,
                            Day = 6,
                            DoctorId = 6,
                            IsDeleted = false
                        },
                        new
                        {
                            ScheduleId = 7,
                            ClinicId = 4,
                            Day = 0,
                            DoctorId = 7,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Reservio.Models.Vacation", b =>
                {
                    b.Property<int>("VacationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacationId"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.HasKey("VacationId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("Reservio.Models.Reservation", b =>
                {
                    b.HasOne("Reservio.Models.Clinic", "Clinic")
                        .WithMany("Reservations")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reservio.Models.Patient", null)
                        .WithMany("Reservations")
                        .HasForeignKey("PatientId");

                    b.Navigation("Clinic");
                });

            modelBuilder.Entity("Reservio.Models.Schedule", b =>
                {
                    b.HasOne("Reservio.Models.Clinic", "Clinic")
                        .WithMany("Schedules")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reservio.Models.Doctor", "Doctor")
                        .WithMany("Schedules")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Reservio.Models.Vacation", b =>
                {
                    b.HasOne("Reservio.Models.Doctor", null)
                        .WithMany("Vacations")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reservio.Models.Clinic", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Reservio.Models.Doctor", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("Vacations");
                });

            modelBuilder.Entity("Reservio.Models.Patient", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
