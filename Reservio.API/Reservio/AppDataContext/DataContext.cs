using Reservio.Models;
using Microsoft.EntityFrameworkCore;
using Reservio.Enums;
using Reservio.Core;

namespace Reservio.AppDataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservation>().HasKey(r => r.ReservationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(c => c.Clinic)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.ClinicId);



            modelBuilder.Entity<Schedule>().HasKey(s => s.ScheduleId);
            modelBuilder.Entity<Schedule>()
                .HasOne(d => d.Doctor)
                .WithMany(s => s.Schedules)
                .HasForeignKey(sid => sid.DoctorId);

            modelBuilder.Entity<Schedule>()
              .HasOne(d => d.Clinic)
              .WithMany(s => s.Schedules)
              .HasForeignKey(sid => sid.ClinicId);

            #region DataSeeding
            modelBuilder.Entity<Clinic>().HasData(GetClinics());
            modelBuilder.Entity<Doctor>().HasData(GetDoctors());
            modelBuilder.Entity<Schedule>().HasData(GetSchedules());
            modelBuilder.Entity<Reservation>().HasData(GetReservations());
            #endregion
        }

        private List<Clinic> GetClinics()
        {
            //Assumes that you have a data source or database access to retrieve clinics
            List<Clinic> clinics = new List<Clinic>();

            //Clinic data
            clinics.Add(new Clinic { ClinicId = 1, Name = "Heart Clinic", CountPaitentAccepted = 10 });
            clinics.Add(new Clinic { ClinicId = 2, Name = "Children's Clinic", CountPaitentAccepted = 5});
            clinics.Add(new Clinic { ClinicId = 3, Name = "Eye Clinic", CountPaitentAccepted = 8 });

            clinics.Add(new Clinic { ClinicId = 4, Name = "Ear, Nose and Throat Clinic", CountPaitentAccepted = 12 });
            clinics.Add(new Clinic { ClinicId = 5, Name = "Dermatology Clinic", CountPaitentAccepted = 15 });

            return clinics;
        }

        private List<Doctor> GetDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            // Add doctors to the list
            doctors.Add(new Doctor { DoctorId = 1, FullName = "Dr. Smith", Specialist = "Cardiology" });
            doctors.Add(new Doctor { DoctorId = 2, FullName = "Dr. Johnson", Specialist = "Cardiology" });
            doctors.Add(new Doctor { DoctorId = 3, FullName = "Dr. Williams", Specialist = "Pediatrics" });
            doctors.Add(new Doctor { DoctorId = 4, FullName = "Dr. Brown", Specialist = "Pediatrics" });
            doctors.Add(new Doctor { DoctorId = 5, FullName = "Dr. Jones", Specialist = "Ophthalmology" });
            doctors.Add(new Doctor { DoctorId = 6, FullName = "Dr. Davis", Specialist = "Ophthalmology" });
            doctors.Add(new Doctor { DoctorId = 7, FullName = "Dr. Miller", Specialist = "ENT" });
            doctors.Add(new Doctor { DoctorId = 8, FullName = "Dr. Wilson", Specialist = "ENT" });
            doctors.Add(new Doctor { DoctorId = 9, FullName = "Dr. Moore", Specialist = "Dermatology" });
            doctors.Add(new Doctor { DoctorId = 10, FullName = "Dr. Taylor", Specialist = "Dermatology" });

            return doctors;
        }

        private List<Schedule> GetSchedules()
        {
            List<Schedule> schedules = new List<Schedule>();

            // Add schedules to the list
            schedules.Add(new Schedule { ScheduleId = 1, DoctorId = 1, ClinicId = 1, DayOfWeek = DayOfWeek.Monday });
            schedules.Add(new Schedule { ScheduleId = 2, DoctorId = 2, ClinicId = 1, DayOfWeek = DayOfWeek.Tuesday });
            schedules.Add(new Schedule { ScheduleId = 3, DoctorId = 3, ClinicId = 2, DayOfWeek = DayOfWeek.Wednesday });
            schedules.Add(new Schedule { ScheduleId = 4, DoctorId = 4, ClinicId = 3, DayOfWeek = DayOfWeek.Thursday });
            schedules.Add(new Schedule { ScheduleId = 5, DoctorId = 5, ClinicId = 3, DayOfWeek = DayOfWeek.Friday });
            schedules.Add(new Schedule { ScheduleId = 6, DoctorId = 6, ClinicId = 4, DayOfWeek = DayOfWeek.Saturday });
            schedules.Add(new Schedule { ScheduleId = 7, DoctorId = 7, ClinicId = 4, DayOfWeek = DayOfWeek.Sunday });

            return schedules;
        }

        private List<Reservation> GetReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            reservations.Add(new Reservation
            {
                ReservationId = 1,
                FirstName = "Abdullah",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = GenderPaintet.Male,
                Resgoin = "Reason for reservation 1",
                PhoneNumber = "1234567890",
                IPAddress = "192.168.0.1",
                Date = DateTime.Now.AddHours(5),
                BookFor = ReservationHelper.DetermineBookingDate(DateTime.Now),
                IsDeleted = false,
                ClinicId = 1, // Heart Clinic
            });

            reservations.Add(new Reservation
            {
                ReservationId = 2,
                FirstName = "Omar",
                LastName = "Doe",
                DateOfBirth = new DateTime(1985, 5, 15),
                Gender = GenderPaintet.Female,
                Resgoin = "Reason for reservation 2",
                PhoneNumber = "9876543210",
                IPAddress = "192.168.0.2",
                Date = DateTime.Now.AddHours(7),
                BookFor = ReservationHelper.DetermineBookingDate(DateTime.Now),
                IsDeleted = false,
                ClinicId = 2, // Children's Clinic
            });

            reservations.Add(new Reservation
            {
                ReservationId = 3,
                FirstName = "Saad",
                LastName = "Smith",
                DateOfBirth = new DateTime(1982, 8, 20),
                Gender = GenderPaintet.Female,
                Resgoin = "Reason for reservation 3",
                PhoneNumber = "5551234567",
                IPAddress = "192.168.0.3",
                Date = DateTime.Now.AddHours(4),
                BookFor = ReservationHelper.DetermineBookingDate(DateTime.Now),
                IsDeleted = false,
                ClinicId = 3, // Eye Clinic
            });

            reservations.Add(new Reservation
            {
                ReservationId = 4,
                FirstName = "Ammar",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1975, 3, 10),
                Gender = GenderPaintet.Male,
                Resgoin = "Reason for reservation 4",
                PhoneNumber = "3339876543",
                IPAddress = "192.168.0.4",
                Date = DateTime.Now.AddHours(10),
                BookFor = ReservationHelper.DetermineBookingDate(DateTime.Now),
                IsDeleted = false,
                ClinicId = 4, // Ear, Nose and Throat Clinic
            });

            reservations.Add(new Reservation
            {
                ReservationId = 5,
                FirstName = "Ali",
                LastName = "Anderson",
                DateOfBirth = new DateTime(1988, 12, 5),
                Gender = GenderPaintet.Female,
                Resgoin = "Reason for reservation 5",
                PhoneNumber = "1112223333",
                IPAddress = "192.168.0.5",
                Date = DateTime.Now.AddHours(1),
                BookFor = ReservationHelper.DetermineBookingDate(DateTime.Now),
                IsDeleted = false,
                ClinicId = 5, // Dermatology Clinic
            });

            reservations.Add(new Reservation
            {
                ReservationId = 6,
                FirstName = "Michael",
                LastName = "Clark",
                DateOfBirth = new DateTime(1978, 6, 18),
                Gender = GenderPaintet.Male,
                Resgoin = "Reason for reservation 6",
                PhoneNumber = "9998887777",
                IPAddress = "192.168.0.6",
                Date = DateTime.Now.AddHours(10),
                BookFor = ReservationHelper.DetermineBookingDate(DateTime.Now),
                IsDeleted = false,
                ClinicId = 1, // Heart Clinic
            });

            reservations.Add(new Reservation
            {
                ReservationId = 7,
                FirstName = "Sophia",
                LastName = "Brown",
                DateOfBirth = new DateTime(1995, 4, 30),
                Gender = GenderPaintet.Female,
                Resgoin = "Reason for reservation 7",
                PhoneNumber = "7775558888",
                IPAddress = "192.168.0.7",
                Date = DateTime.Now.AddHours(2),
                BookFor = ReservationHelper.DetermineBookingDate(DateTime.Now),
                IsDeleted = false,
                ClinicId = 3, // Eye Clinic
            });
            return reservations;
        }
    }
}
