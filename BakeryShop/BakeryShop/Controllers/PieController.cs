using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BakeryShop.ViewModels;
using Domain.Core;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BakeryShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository, IHostingEnvironment hostingEnvironment)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;
            _hostingEnvironment = hostingEnvironment;
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
            model.Categories = new List<SelectListItem>();
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
                    InStock = model.InStock,
                    ImageThumbnail = model.ImageThumbnailUrl,
                    IsPieOfTheWeek = model.IsPieOfTheWeek,
                    LongDescription = model.LongDescription,
                    Price = Convert.ToDecimal(model.Price)
                };
                if (model.ImageFile != null)
                {
                    string uniqueFileName = UploadFile(model);
                    pie.Image = uniqueFileName;
                }
                else
                {
                    pie.Image = model.ImageUrl;
                }
                _pieRepository.CreatePie(pie);
                return RedirectToAction("Index");
            }
            model.Categories = new List<SelectListItem>();
            foreach (var category in _categoryRepository.AllCategories)
            {
                model.Categories.Add(new SelectListItem { Value = category.CategoryId.ToString(), Text = category.CategoryName });
            }
            model.CategoryId = 1;
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
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
                ImageThumbnailUrl = pie.ImageThumbnail,
                InStock = pie.InStock,
                IsPieOfTheWeek = pie.IsPieOfTheWeek,
                LongDescription = pie.LongDescription,
                Price = pie.Price,
                Categories = new List<SelectListItem>()
            };
            if (Uri.IsWellFormedUriString(pie.Image, UriKind.Absolute))
            {
                model.ImageUrl = pie.Image;
            }
            else
            {
                model.ExistingImageFilePath = pie.Image;
            }
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
                    pie.ImageThumbnail = model.ImageThumbnailUrl;
                    pie.InStock = model.InStock;
                    pie.IsPieOfTheWeek = model.IsPieOfTheWeek;
                    pie.LongDescription = model.LongDescription;
                    pie.Price = Convert.ToDecimal(model.Price);
                    if(model.ImageUrl!=null)
                    {
                        pie.Image = model.ImageUrl;
                    }
                    if (model.ImageFile != null)
                    {
                        if (model.ExistingImageFilePath != null)
                        {
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                                "images", model.ExistingImageFilePath);
                            System.IO.File.Delete(filePath);
                        }
                        pie.Image = UploadFile(model);
                    }

                    _pieRepository.UpdatePie(pie);
                    return RedirectToAction("Index");
                }
            }
            model.Categories = new List<SelectListItem>();
            foreach (var category in _categoryRepository.AllCategories)
            {
                model.Categories.Add(new SelectListItem { Value = category.CategoryId.ToString(), Text = category.CategoryName });
            }
            return View(model);
        }

        private string UploadFile(CreatePieViewModel model)
        {
            string uniqueFileName = null;
            if (model.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
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
