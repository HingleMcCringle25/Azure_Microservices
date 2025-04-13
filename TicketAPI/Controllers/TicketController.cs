using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

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
        public async Task<IActionResult> Post(TicketHub ticket)
        {
            //validate ticket

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            //post message to azure storage queue
            string queueName = "tickets";
            
            //get connection string
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error has occured.");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            //serialize an object to json
            string message = JsonSerializer.Serialize(ticket);

            //send string message to queue (encode to base 64)
            var plainTextBytes = Encoding.UTF8.GetBytes(message);
            await queueClient.SendMessageAsync(Convert.ToBase64String(plainTextBytes));

            return Ok("Ticket information sent to storage queue.");
        }
    }
}
