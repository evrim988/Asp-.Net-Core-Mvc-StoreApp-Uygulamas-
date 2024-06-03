using Entities.Dtos.Category;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.CategoryService.GetListCategories(false);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryDTO model)
        {
            _manager.CategoryService.CreateCategory(model);
            return RedirectToAction("Index");

        }

        public IActionResult Update(int Id)
        {
            var model = _manager.CategoryService.UpdateCategoryById(Id, false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category model)
        {
            _manager.CategoryService.UpdateCategory(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            _manager.CategoryService.DeleteCategory(Id);
            return RedirectToAction("Index");
        }


    }
}
