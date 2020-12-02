using Domain.Core;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> AllCategories => _appDbContext.Categories;
    }
}
