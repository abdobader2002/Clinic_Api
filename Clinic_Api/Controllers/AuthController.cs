using Clinic_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        
    }
}
