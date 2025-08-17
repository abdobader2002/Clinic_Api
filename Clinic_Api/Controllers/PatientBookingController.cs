using Clinic_Api.DTOs;
using Clinic_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientBookingController : ControllerBase
    {
        private readonly ClinicDBContext _context;
        public PatientBookingController(ClinicDBContext context)
        {
            _context = context;
        }
        [HttpGet("userbookings/{userId}")]
        public async Task<IActionResult> GetUserBookings(int userId)
        {
            var bookings = await _context.Bookings
                .Include(b => b.Doctor)
                .Include(b => b.Patient)
                .Where(b => b.PatientId == userId)
                .ToListAsync();
            if (bookings == null || !bookings.Any())
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "No bookings found for this user"
                });
            }
            var responseBookings = bookings.Select(b => new
            {
                b.Id,
                b.DoctorId,
                b.BookingDate,
                b.BookingTime,
                b.Notes,
                Doctor = new
                {
                    b.Doctor.Id,
                    b.Doctor.Name
                },

                Status = b.Status.ToString(),
            }).ToList();
            return Ok(new
            {
                Success = true,
                Message = "User bookings retrieved successfully",
                Data = responseBookings
            });
        
        }
        //make booking for user
        [HttpPost("NewBookings")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patient = await _context.Patients.FindAsync(bookingdto.PatientId);
            if (patient == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "Patient not found"
                });
            }
            var doctor = await _context.Doctors.FindAsync(bookingdto.DoctorId);
            if (doctor == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "Doctor not found"
                });
            }
            var booking = new Booking
            {
                PatientId = bookingdto.PatientId,
                DoctorId = bookingdto.DoctorId,
                BookingDate = bookingdto.BookingDate,
                BookingTime = bookingdto.BookingTime,
                Notes = bookingdto.Notes,
                Status = BookingStatus.Pending
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Success = true,
                Message = "Booking created successfully",
                Data = booking
            });
        }

        //get the booking by id
        [HttpGet("booking/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Doctor)
                .Include(b => b.Patient)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (booking == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "Booking not found"
                });
            }
            return Ok(new
            {
                Success = true,
                Message = "Booking retrieved successfully",
                Data = new
                {
                    booking.Id,
                    booking.DoctorId,
                    booking.PatientId,
                    booking.BookingDate,
                    booking.BookingTime,
                    booking.Notes,
                    Doctor = new
                    {
                        booking.Doctor.Id,
                        booking.Doctor.Name
                    },
                    Patient = new
                    {
                        booking.Patient.Id,
                        booking.Patient.Name
                    },
                    Status = booking.Status.ToString(),
                }
            });
        }
    }
}
