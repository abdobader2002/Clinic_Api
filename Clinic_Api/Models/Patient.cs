namespace Clinic_Api.Models
{
    public class Patient: User
    {
        public DateOnly? Birthdate { get; set; }
        public string? MedicalRecord { get; set; }
        public ICollection<Booking> ?Bookings { get; set; } 
    }
}
