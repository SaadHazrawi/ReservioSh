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

            modelBuilder.Entity<Reservation>()
              .HasOne(c => c.Patient)
              .WithMany(r => r.Reservations)
              .HasForeignKey(r => r.PatientId);

            modelBuilder.Entity<Substitute>().HasKey(s => s.SubstituteId);
            modelBuilder.Entity<Substitute>()
                .HasOne(d => d.Doctor)
                .WithMany(s => s.Substitutes)
                .HasForeignKey(sid => sid.DoctorId);
            modelBuilder.Entity<Substitute>()
              .HasOne(d => d.Clinic)
              .WithMany(s => s.Substitutes)
              .HasForeignKey(sid => sid.ClinicId);
        }
    }
}
