using Domain.Core;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICommentRepository
    {
        public IEnumerable<Comment> AllComments { get; }
        public void CreateComment(Comment comment);
    }
}
