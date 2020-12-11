using Domain.Core;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BakeryShop.Tests
{
    public class CommentTest
    {
        private CommentRepository commentRepository;
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=commentTestDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        static CommentTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public CommentTest()
        {
            var context = new AppDbContext(dbContextOptions);
            DataInitializer db = new DataInitializer();
            db.Init(context);

            commentRepository = new CommentRepository(context);
        }

        [Fact]
        public void TestAllComments()
        {
            var comments = commentRepository.AllComments;
            Assert.NotNull(comments);
            Assert.Equal(2, comments.ToList().Count);
            Assert.IsAssignableFrom<IEnumerable<Comment>>(comments);
        }

        [Fact]
        public void TestCreateComment()
        {
            var comments = commentRepository.AllComments;
            Assert.NotNull(comments);
            Assert.Equal(2, comments.ToList().Count);

            commentRepository.CreateComment(new Comment { CommentMessage = "Hi", ApplicationUserId="1" });

            comments = commentRepository.AllComments;
            Assert.NotNull(comments);
            Assert.Equal(3, comments.ToList().Count);
        }
    }
}
