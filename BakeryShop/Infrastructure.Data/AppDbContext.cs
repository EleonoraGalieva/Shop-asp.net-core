using Domain.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Apple pies" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Pumpkin pies" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Cheesecakes" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Pies with nuts" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Ice cream pie" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 6, CategoryName = "Other" });
            modelBuilder.Entity<Pie>().HasData(new Pie
            {
                PieId = 1,
                IsPieOfTheWeek = false,
                Name = "Sofia",
                Price = 12.95M,
                ShortDescription = "The best apple pie ever!",
                LongDescription = "I remember coming home sullen one day because we'd " +
                "lost a softball game. Grandma, in her wisdom, suggested, \"Maybe a slice " +
                "of my homemade apple pie will make you feel better.\"" +
                " One bite, and Grandma was right. If you want to learn how to make " +
                "homemade apple pie filling, this is really the only recipe you need." +
                " —Maggie Greene, Granite Falls, Washington",
                CategoryId = 1,
                Image = "https://img.grouponcdn.com/seocms/2i7116adj14eoCiYBx8SQLUzXZrq/671x671_Apple_Pie_BUYING_GUIDE_DIFFERENT_TYPES_OF_PIE_012319_ak_jpg-671x671",
                InStock = true,
                AllergyInfo = "Contains sugar, milk, apples, gluten",
            });

            modelBuilder.Entity<Pie>().HasData(new Pie
            {
                PieId = 2,
                IsPieOfTheWeek = true,
                Name = "Autumn Wonders",
                Price = 16.45M,
                ShortDescription = "Yummy pie for autmn.",
                LongDescription = "This is absolutely the BEST homemade " +
                "pumpkin pie recipe! Make it with canned or fresh pumpkin puree " +
                "and up to several days ahead. Also freezes well! Thanksgiving pie never " +
                "looked so good or so easy.",
                CategoryId = 2,
                Image = "https://images.ctfassets.net/3s5io6mnxfqz/3RG0DDIeU6oW5XG04n2JSN/6f55a3abe26a310adf6ac1eeccbd811e/AdobeStock_177050939.jpeg?w=800&fm=jpg&fl=progressive",
                InStock = true,
                AllergyInfo = "Contains sugar, milk, gluten",
            });

            modelBuilder.Entity<Pie>().HasData(new Pie
            {
                PieId = 3,
                IsPieOfTheWeek = false,
                Name = "Soft cheesecake",
                Price = 10.20M,
                ShortDescription = "THE BEST cheesecake of your life!",
                LongDescription = "Simple and classic! " +
                "The texture is smooth, rich, and creamy, served over a " +
                "crisp homemade graham cracker crust.",
                CategoryId = 3,
                Image = "https://i2.wp.com/www.sugarspunrun.com/wp-content/uploads/2019/01/Best-Cheesecake-Recipe-2-1-of-1-4.jpg",
                InStock = true,
                AllergyInfo = "Contains sugar, milk, gluten",
            });
        }
    }
}
