using Domain.Core;
using Domain.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _appDbContext;
        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Comment> AllComments => _appDbContext.Comments.Include(u => u.ApplicationUser);

        public void CreateComment(Comment comment)
        {
            _appDbContext.Comments.Add(comment);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Comment> FindAllByPieId(int pieId)
        {
            return _appDbContext.Comments.Include(u => u.ApplicationUser).Where(p => p.Pie.PieId == pieId);
        }

        public int GetAmountByPieId(int pieId)
        {
            return _appDbContext.Comments.Include(u => u.ApplicationUser).Where(p => p.Pie.PieId == pieId).ToList().Count;
        }
    }
}
