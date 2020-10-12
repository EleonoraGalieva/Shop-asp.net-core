using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Pie> AllPies =>
            new List<Pie>
            {
                new Pie{PieId=1, Name="Strawberry pie", Price=15.95M, ShortDescription="siuefh", LongDescription="woiehfowf"},
                new Pie{PieId=2, Name="Blueberry pie", Price=16.95M, ShortDescription="pwodjw", LongDescription="wdhwid"},
                new Pie{PieId=3, Name="Pumpkin pie", Price=20.95M, ShortDescription="wfjef", LongDescription="wkfk"},

            };

        public IEnumerable<Pie> PiesOfTheWeek { get; }

        public Pie GetPieById(int pieId)
        {
            return AllPies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
