using System.ComponentModel.DataAnnotations;
using Clinic_Api.Models;

namespace Clinic_Api.DTOs
{
    public class BookingDto
    {
        [Required(ErrorMessage = "DoctorId is required")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "PatientId is required")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "BookingDate is required")]
        public DateOnly BookingDate { get; set; }
        [Required(ErrorMessage = "BookingTime is required")]
        public TimeOnly BookingTime { get; set; }
        public string ?Notes { get; set; }
    }
}
