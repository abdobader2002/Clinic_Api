namespace Clinic_Api.Models
{
    public class Patient: User
    {
        public DateOnly? Birthdate { get; set; }
        public string? MedicalRecord { get; set; }
        public List<Booking> ?Bookings { get; set; } = new List<Booking>();
    }
}
