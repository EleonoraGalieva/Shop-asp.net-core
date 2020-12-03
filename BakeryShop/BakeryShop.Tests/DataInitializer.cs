using Domain.Core;
using Infrastructure.Data;

namespace BakeryShop.Tests
{
    public class DataInitializer
    {
        public DataInitializer()
        {

        }

        public void Init(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Comments.AddRange(
                new Comment { CommentMessage = "Hello", NameComment = "Mike" },
                new Comment { CommentMessage = "Bye", NameComment = "Nick" });

            context.SaveChanges();
        }
    }
}