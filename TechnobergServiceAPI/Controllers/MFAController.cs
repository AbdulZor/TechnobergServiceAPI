using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TechnobergService.Controllers;
using TechnobergServiceAPI.Data;
using TechnobergServiceAPI.Models;

namespace TechnobergServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MFAController : ControllerBase
    {
        private const string SUCCESS_MESSAGE = "User accepted the login attempt.";
        private const string FAILURE_MESSAGE = "User denied the login attempt.";

        private readonly ILogger<MFAController> _logger;
        private readonly TechnobergServiceContext _context;
        public MFAController(ILogger<MFAController> logger, TechnobergServiceContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("ip")]
        [HttpGet]
        public IActionResult getip()
        {
            string ip = this.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Console.WriteLine(ip);

            return Ok(ip);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get([Required] string username, [Required] string method)
        {
            // Identify and retrieve the user that requests the MFA attempt
            User? user = null;
            if (user == null)
            {
                return NotFound(new
                {
                    message = "User does not exist."
                });
            }

            bool authSucceeded = false;
            switch (method)
            {
                case "push":
                    authSucceeded = HandlePushNotification(user);
                    break;
                default:
                    return BadRequest(new SyncApiResponse(ResultType.Deny, FAILURE_MESSAGE));
            }

            if (authSucceeded)
            {
                return Ok(new SyncApiResponse(ResultType.Allow, SUCCESS_MESSAGE));
            }
            else
            {
                return BadRequest(new SyncApiResponse(ResultType.Deny, FAILURE_MESSAGE));
            }
        }

        private bool HandlePushNotification(User User)
        {
            Console.Write($"Do you want to login? ");
            string response = Console.ReadLine();

            return response == "yes";
        }


    }
}
