namespace Clinic_Api.Models
{
    public class Doctor: User
    {
        public string Specialization { get; set; }
        public string? Description { get; set; }
        public List<Booking>? Bookings { get; set; } = new List<Booking>();
    }
}
