using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product model)
        {
            if(ModelState.IsValid)
            {
                _manager.ProductService.CreateProduct(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int Id)
        {
            var model = _manager.ProductService.GetProductById(Id, false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product model)
        {
            if(ModelState.IsValid)
            {
                _manager.ProductService.UpdateProduct(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _manager.ProductService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
