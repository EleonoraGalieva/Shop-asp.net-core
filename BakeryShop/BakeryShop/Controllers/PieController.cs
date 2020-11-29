using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.Models;
using BakeryShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                piesListViewModel.Pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == currentCategory).OrderBy(p => p.PieId);
            }
            piesListViewModel.CurrentCategory = currentCategory;

            return View(piesListViewModel);
        }
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                Response.StatusCode = 404;
                return View("PieNotFound");
            }
            return View(pie);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index() => View(_pieRepository.AllPies.ToList());
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            CreatePieViewModel model = new CreatePieViewModel();
            foreach (var category in _categoryRepository.AllCategories)
            {
                model.Categories.Add(new SelectListItem { Value = category.CategoryId.ToString(), Text = category.CategoryName });
            }
            model.CategoryId = 1;
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(CreatePieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pie = new Pie
                {
                    Name = model.Name,
                    ShortDescription = model.ShortDescription,
                    AllergyInfo = model.AllergyInfo,
                    CategoryId = model.CategoryId,
                    ImageThumbnailUrl = model.ImageThumbnailUrl,
                    ImageUrl = model.ImageUrl,
                    InStock = model.InStock,
                    IsPieOfTheWeek = model.IsPieOfTheWeek,
                    LongDescription = model.LongDescription,
                    Price = Convert.ToDecimal(model.Price)
                };
                _pieRepository.CreatePie(pie);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }
            EditPieViewModel model = new EditPieViewModel
            {
                Id = pie.PieId,
                Name = pie.Name,
                ShortDescription = pie.ShortDescription,
                AllergyInfo = pie.AllergyInfo,
                ImageThumbnailUrl = pie.ImageThumbnailUrl,
                ImageUrl = pie.ImageUrl,
                InStock = pie.InStock,
                IsPieOfTheWeek = pie.IsPieOfTheWeek,
                LongDescription = pie.LongDescription,
                Price = pie.Price
            };
            foreach (var category in _categoryRepository.AllCategories)
            {
                model.Categories.Add(new SelectListItem { Value = category.CategoryId.ToString(), Text = category.CategoryName });
            }
            model.CategoryId = pie.CategoryId;
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Edit(EditPieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pie = _pieRepository.GetPieById(model.Id);
                if (pie != null)
                {
                    pie.Name = model.Name;
                    pie.ShortDescription = model.ShortDescription;
                    pie.AllergyInfo = model.AllergyInfo;
                    pie.CategoryId = model.CategoryId;
                    pie.ImageThumbnailUrl = model.ImageThumbnailUrl;
                    pie.ImageUrl = model.ImageUrl;
                    pie.InStock = model.InStock;
                    pie.IsPieOfTheWeek = model.IsPieOfTheWeek;
                    pie.LongDescription = model.LongDescription;
                    pie.Price = Convert.ToDecimal(model.Price);

                    _pieRepository.UpdatePie(pie);
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie != null)
            {
                _pieRepository.DeletePie(pie);
            }
            return RedirectToAction("Index");
        }
    }
}
