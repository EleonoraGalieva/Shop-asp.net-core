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
            context.Users.Add(new ApplicationUser { UserName = "ela", Email = "ela@gmail.com", Id = "1" });
            context.Comments.AddRange(
                new Comment { CommentMessage = "Hello", ApplicationUserId = "1" },
                new Comment { CommentMessage = "Bye", ApplicationUserId = "1" });

            context.SaveChanges();
        }
    }
}