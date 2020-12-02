using BakeryShop.ViewModels;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BakeryShop.Controllers
{
    public class ReviewsController : Controller
    {
        private ICommentRepository _commentRepository;
        public ReviewsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public IActionResult Index()
        {
            var commentViewModel = new CommentsListViewModel { Comments = _commentRepository.AllComments };
            return View(commentViewModel);
        }
    }
}
