using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnobergServiceAPI.Data;

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
        [Route("AuthenticationCode")]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}
