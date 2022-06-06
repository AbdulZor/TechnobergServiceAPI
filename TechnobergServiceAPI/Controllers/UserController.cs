using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnobergServiceAPI.Data;
using TechnobergServiceAPI.Models;

namespace TechnobergServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly TechnobergServiceContext _context;
        public UserController(ILogger<UserController> logger, TechnobergServiceContext context)
        {
            _logger = logger;
            _context = context;
            // Creates the database if it does not exists
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUsers()
        {
            ICollection<User> users = _context.User.ToList();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}
