using BakeryShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.ViewModels
{
    public class CommentsListViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}
