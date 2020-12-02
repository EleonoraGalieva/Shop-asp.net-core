using Domain.Core;
using Domain.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class CommentHub : Hub
    {
        private ICommentRepository _commentRepository;
        public CommentHub(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task SendMessage(string user, string message)
        {
            _commentRepository.CreateComment(new Comment { CommentMessage = message, NameComment = user });
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
