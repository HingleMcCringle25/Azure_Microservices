using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly IConfiguration _configuration;

        public TicketController(ILogger<TicketController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from TicketController!");
        }

        [HttpPost]
        public IActionResult Post(Ticket ticket)
        {
            //validate ticket
            if (string.IsNullOrEmpty(ticket.FirstName))
            {
                return BadRequest("Invalid first name");
            }
            if (string.IsNullOrEmpty(ticket.LastName))
            {
                return BadRequest("Invalid last name");
            }

            return Ok("Hello " + ticket.FirstName + " " + ticket.LastName + " from TicketController!");
        }
    }
}
