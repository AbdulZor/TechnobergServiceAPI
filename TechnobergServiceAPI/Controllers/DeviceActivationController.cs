using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnobergServiceAPI.Data;
using TechnobergServiceAPI.Models;
using TechnobergServiceAPI.Utils;

namespace TechnobergServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceActivationController : ControllerBase
    {
        private readonly ILogger<DeviceActivationController> _logger;
        private readonly TechnobergServiceContext _context;
        public DeviceActivationController(ILogger<DeviceActivationController> logger, TechnobergServiceContext context)
        {
            _logger = logger;
            _context = context;
            // Creates the database if it does not exists
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("ActivationCode")]
        public IActionResult GetNewActivationCode(string username)
        {
            User? user = _context.User.FirstOrDefault<User>(element => String.Equals(element.Username, username));

            if (user == null) return NotFound();

            ActivationRequest activationRequest = new()
            {
                User = user,
                ActivationCode = CodeGeneration.CreateActivationCode().ToString()
            };
            _context.ActivationRequest.Add(activationRequest);
            _context.SaveChanges();

            return Created("", new { activationCode = activationRequest.ActivationCode });
        }

        [HttpPost]
        public IActionResult ActivateDevice(string activationCode, string deviceToken, string OS)
        {
            if (string.IsNullOrEmpty(activationCode) || 
                string.IsNullOrEmpty(deviceToken) || 
                string.IsNullOrEmpty(OS)) return NotFound();

            // Verify activation code
            var activationRequest = _context.ActivationRequest.FirstOrDefault(element => element.ActivationCode.Equals(activationCode));
            if (activationRequest == null) return NotFound();
            _context.Entry(activationRequest).Reference(ar => ar.User).Load();

            var existingDevice = _context.Device.FirstOrDefault(element => string.Equals(element.DeviceToken, deviceToken));
            _context.SaveChanges();
            if (existingDevice != null) return BadRequest();

            // Store Device for the User
            Device userDevice = new()
            {
                User = activationRequest.User,
                DeviceToken = deviceToken,
                OperatingSystem = OS
            };
            _context.Device.Add(userDevice);
            _context.SaveChanges();

            return Ok();
        }

    }
}
