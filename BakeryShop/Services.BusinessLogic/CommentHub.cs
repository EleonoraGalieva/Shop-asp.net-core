using Domain.Core;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public class CommentHub : Hub
    {
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPieRepository _pieRepository;
        public CommentHub(UserManager<ApplicationUser> userManager, ICommentRepository commentRepository, IPieRepository pieRepository)
        {
            _userManager = userManager;
            _commentRepository = commentRepository;
            _pieRepository = pieRepository;
        }
        public async Task SendMessage(string pieId, string message)
        {
            var user = await _userManager.FindByNameAsync(Context.User.Identity.Name);
            var comment = new Comment
            {
                CommentMessage = message,
                ApplicationUser = user,
                Pie = _pieRepository.GetPieById(Int32.Parse(pieId))
            };
            _commentRepository.CreateComment(comment);
            int amount = _commentRepository.GetAmountByPieId(Int32.Parse(pieId));
            await Clients.Group(pieId).SendAsync("ReceiveMessage", user.UserName, message, amount);
        }
        public async Task JoinPieGroup(string pieId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, pieId);
        }
    }
}
