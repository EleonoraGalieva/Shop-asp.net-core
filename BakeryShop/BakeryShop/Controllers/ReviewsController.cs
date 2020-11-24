using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.Models;
using BakeryShop.ViewModels;
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
