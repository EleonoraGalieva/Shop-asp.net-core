using Xunit;
using System.Collections.Generic;
using System.Linq;
using Domain.Core;
using Moq;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BakeryShop.Tests
{
    public class PieTest
    {

        private PieRepository pieRepository;
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=pieTestDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        static PieTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public PieTest()
        {
            var context = new AppDbContext(dbContextOptions);
            DataInitializer db = new DataInitializer();
            db.Init(context);

            pieRepository = new PieRepository(context);
        }

        [Fact]
        public void TestPiesOfTheWeek()
        {
            var pies = pieRepository.PiesOfTheWeek;
            Assert.NotNull(pies);
            Assert.Single(pies.ToList());
            Assert.IsAssignableFrom<IEnumerable<Pie>>(pies);
        }

        [Fact]
        public void TestAllPies()
        {
            var pies = pieRepository.AllPies;
            Assert.NotNull(pies);
            Assert.Equal(3, pies.ToList().Count);
            Assert.IsAssignableFrom<IEnumerable<Pie>>(pies);
        }

        [Fact]
        public void TestCreatePie()
        {
            var pies = pieRepository.AllPies;
            Assert.NotNull(pies);
            Assert.Equal(3, pies.ToList().Count);

            pieRepository.CreatePie(new Pie
            {
                IsPieOfTheWeek = true,
                Name = "Icecream pie",
                Price = 10.30M,
                ShortDescription = "THE BEST icecream pie ever!",
                LongDescription = "So if you love ice cream, " +
                "you should totally give this a try!",
                CategoryId = 5,
                ImageUrl = "https://www.mysequinedlife.com/wp-content/uploads/2016/08/no-bake-ice-cream-pie-1.jpg",
                InStock = true,
                ImageThumbnailUrl = "https://www.mysequinedlife.com/wp-content/uploads/2016/08/no-bake-ice-cream-pie-1.jpg",
                AllergyInfo = "Contains sugar, milk, gluten",
            });

            pies = pieRepository.AllPies;
            Assert.NotNull(pies);
            Assert.Equal(4, pies.ToList().Count);
        }

        [Fact]
        public void TestDeletePie()
        {
            var pies = pieRepository.AllPies;
            Assert.NotNull(pies);
            Assert.Equal(3, pies.ToList().Count);

            pieRepository.DeletePie(pieRepository.GetPieById(1));

            pies = pieRepository.AllPies;
            Assert.NotNull(pies);
            Assert.Equal(2, pies.ToList().Count);
        }

        [Fact]
        public void TestUpdatePie()
        {
            var pie = pieRepository.GetPieById(1);
            pie.Name = "Maria";
            pieRepository.UpdatePie(pie);
            pie = pieRepository.GetPieById(1);
            Assert.NotNull(pie);
            Assert.Equal("Maria", pie.Name);
        }

        [Fact]
        public void TestGetPieById()
        {
            var pie = pieRepository.GetPieById(1);
            Assert.Equal(1, pie.PieId);
        }
    }
}
