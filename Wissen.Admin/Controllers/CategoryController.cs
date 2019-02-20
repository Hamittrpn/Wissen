using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wissen.Model;
using Wissen.Service;

namespace Wissen.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryService.GetAll();
            return View(categories);
        }

        public ActionResult Create()
        {
            var category = new Category();
            return View(category);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Insert(category);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var category = categoryService.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var model = categoryService.Find(category.Id);
                model.Name = category.Name;
                model.Description = category.Description;
                categoryService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}