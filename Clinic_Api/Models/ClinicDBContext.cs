using Microsoft.EntityFrameworkCore;

namespace Clinic_Api.Models
{
    public class ClinicDBContext: DbContext
    {
        public ClinicDBContext(DbContextOptions<ClinicDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
