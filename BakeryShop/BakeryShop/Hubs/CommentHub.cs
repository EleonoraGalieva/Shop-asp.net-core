using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BakeryShop.Hubs
{
    public class CommentHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
