using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Models
{
    public interface ICommentRepository
    {
        public IEnumerable<Comment> AllComments { get; }
        public void CreateComment(Comment comment);
    }
}
