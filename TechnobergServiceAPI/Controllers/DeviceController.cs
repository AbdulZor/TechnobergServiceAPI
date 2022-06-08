using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnobergServiceAPI.Data;
using TechnobergServiceAPI.Models;

namespace TechnobergServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly TechnobergServiceContext _context;
        public DeviceController(ILogger<DeviceController> logger, TechnobergServiceContext context)
        {
            _logger = logger;
            _context = context;
            // Creates the database if it does not exists
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetDevices()
        {
            ICollection<Device> devices = _context.Device.ToList();
            return Ok(devices);
        }
    }
}
