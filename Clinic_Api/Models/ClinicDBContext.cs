using Microsoft.EntityFrameworkCore;

namespace Clinic_Api.Models
{
    public class ClinicDBContext : DbContext
    {
        public ClinicDBContext(DbContextOptions<ClinicDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Table Per Type (TPT) inheritance
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");

            // Configure the relationship between Booking and Patient
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure the relationship between Booking and Doctor
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Doctor)
                .WithMany(d => d.Bookings)
                .HasForeignKey(b => b.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            // Optional: Configure additional constraints
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}