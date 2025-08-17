using System.ComponentModel.DataAnnotations;

namespace Clinic_Api.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
    }

}
