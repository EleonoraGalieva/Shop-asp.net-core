using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Models
{
    public class MockCategoryRepository:ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Fruit pies", Description="iufh"},
                new Category{CategoryId=2, CategoryName="Cheese cakes", Description="pjf"},
                new Category{CategoryId=3, CategoryName="Wedding cakes", Description="wpqfjpqwojf"}
            };
    }
}
