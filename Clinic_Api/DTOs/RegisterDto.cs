using System.ComponentModel.DataAnnotations;
using Clinic_Api.Models;

namespace Clinic_Api.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Phone number is required")]

        public string Phone { get; set; }
        [Required(ErrorMessage="Gender is required")]
        public Gender Gender { get; set; }
    }
}
