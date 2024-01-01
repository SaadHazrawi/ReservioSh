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
    }
}
