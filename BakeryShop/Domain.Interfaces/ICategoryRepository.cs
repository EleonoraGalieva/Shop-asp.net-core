using Domain.Core;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> AllCategories { get; }
    }
}
