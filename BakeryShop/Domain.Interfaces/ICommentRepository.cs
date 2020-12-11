using Domain.Core;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICommentRepository
    {
        public IEnumerable<Comment> AllComments { get; }
        public int GetAmountByPieId(int pieId);
        public void CreateComment(Comment comment);
        public IEnumerable<Comment> FindAllByPieId(int pieId);
    }
}
