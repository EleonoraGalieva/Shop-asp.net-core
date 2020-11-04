using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.Models;
using BakeryShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BakeryShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;
        }

        public ViewResult List(string currentCategory)
        {
            PiesListViewModel piesListViewModel = new PiesListViewModel();

            if (string.IsNullOrEmpty(currentCategory))
            {
                piesListViewModel.Pies = _pieRepository.AllPies;
                currentCategory = "All pies";
            }
            else
            {
                piesListViewModel.Pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == currentCategory).OrderBy(p=>p.PieId);
            }
            piesListViewModel.CurrentCategory = currentCategory;

            return View(piesListViewModel);
        }
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie==null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
