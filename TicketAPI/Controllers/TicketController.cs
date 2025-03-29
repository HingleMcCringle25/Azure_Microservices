using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Post(Ticket ticket)
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

            //send string message to queue
            await queueClient.SendMessageAsync(message);

            return Ok("Hello " + ticket.FirstName + " " + ticket.LastName + ". Contact sent to storage queue.");
        }
    }
}
