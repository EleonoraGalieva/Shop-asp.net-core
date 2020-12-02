using Domain.Core;
using System.Collections.Generic;

namespace BakeryShop.ViewModels
{
    public class CommentsListViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}
