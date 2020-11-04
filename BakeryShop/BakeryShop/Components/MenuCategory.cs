using BakeryShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Components
{
    public class MenuCategory: ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public MenuCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.AllCategories.OrderBy(p => p.CategoryName);
            return View(categories);
        }
    }
}
