using Clinic_Api.DTOs;
using Clinic_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly ClinicDBContext _context;
        public AuthController(ClinicDBContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingUser = await _context.Patients
               .FirstOrDefaultAsync(p => p.Email == registerDto.Email);

            if (existingUser != null)
            {
                return Conflict(new
                {
                    Success = false,
                    Message = "User with this email already exists"
                });
            }
            var patient = new Patient
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = registerDto.Password,
                Phone = registerDto.Phone,
                Gender = registerDto.Gender,
            };
            try
            {
                _context.Users.Add(patient);
                await _context.SaveChangesAsync();
                return Ok(new {
                    Success= true,
                    Message = "User registered successfully",
                    Data = new
                    {
                        Id = patient.Id,
                        Name = patient.Name,
                        Email = patient.Email,
                        Phone = patient.Phone,
                        Gender = patient.Gender,
                        Role = "Patient",
                        Birthdate = patient.Birthdate,
                        MedicalRecord = patient.MedicalRecord,
                        Bookings = new List<object>() 
                    }
                });
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while registering the user");
            }

        } 
        //login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            if (user == null)
            {
                return Unauthorized(new { Success = false, Message = "Invalid email or password" });
            }
            return Ok(new { Success = true, Message = "Login successful", data = user });
        }

    }

}
