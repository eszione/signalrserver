using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRServer.Hubs
{
    public class MessageHub : Hub
    {
        public async Task TestMethod()
        {
            await Clients.All.SendAsync("message", null, "test message");
        }
    }
}
