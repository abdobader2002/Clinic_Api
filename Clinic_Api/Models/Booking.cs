namespace Clinic_Api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateOnly BookingDate { get; set; }
        public TimeOnly BookingTime { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        public string? Notes { get; set; }
        /******************************/
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        /******************************/
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
}
