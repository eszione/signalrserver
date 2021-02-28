using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs;
using SignalRServer.Models;
using System;

namespace SignalRServer.Controllers.APIs
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hub;

        public MessageController(IHubContext<MessageHub> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        [Route("send")]
        public IActionResult Post()
        {
            var model = new MessageModel
            {
                Date = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt}",
                Message = "Sent"
            };

            _hub.Clients.All.SendAsync("message", "Message sent!");

            return Ok("Message sent!");
        }
    }
}
