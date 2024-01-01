using Reservio.Models;
using Microsoft.EntityFrameworkCore;

namespace Reservio.AppDataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Substitute> Substitutes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservation>().HasKey(r => r.ReservationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(c => c.Clinic)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.ClinicId);



            modelBuilder.Entity<Substitute>().HasKey(s => s.SubstituteId);
            modelBuilder.Entity<Substitute>()
                .HasOne(d => d.Doctor)
                .WithMany(s => s.Substitutes)
                .HasForeignKey(sid => sid.DoctorId);

            modelBuilder.Entity<Substitute>()
              .HasOne(d => d.Clinic)
              .WithMany(s => s.Substitutes)
              .HasForeignKey(sid => sid.ClinicId);

            #region DataSeeding
            modelBuilder.Entity<Clinic>().HasData(GetClinics());
            modelBuilder.Entity<Doctor>().HasData(GetDoctors());
            #endregion
        }

        private List<Clinic> GetClinics()
        {
            //Assumes that you have a data source or database access to retrieve clinics
            List<Clinic> clinics = new List<Clinic>();

            //Clinic data
            clinics.Add(new Clinic { ClinicId = 1, Name = "Heart Clinic", CountPaitentAccepte = 10 });
            clinics.Add(new Clinic { ClinicId = 2, Name = "Children's Clinic", CountPaitentAccepte = 5});
            clinics.Add(new Clinic { ClinicId = 3, Name = "Eye Clinic", CountPaitentAccepte = 8 });

            clinics.Add(new Clinic { ClinicId = 4, Name = "Ear, Nose and Throat Clinic", CountPaitentAccepte = 12 });
            clinics.Add(new Clinic { ClinicId = 5, Name = "Dermatology Clinic", CountPaitentAccepte = 15 });

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
    }
}
