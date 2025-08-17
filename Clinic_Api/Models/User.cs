namespace Clinic_Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
    }
    }
