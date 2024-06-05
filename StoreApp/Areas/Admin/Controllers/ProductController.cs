using Entities.Dtos.Product;
using Entities.Entities;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Abstract;
using StoreApp.Models;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetListCategories(false), "Id", "CategoryName", "1");
        }

        public IActionResult Index([FromQuery]ProductRequestParameters parameters)
        {
            var products = _manager.ProductService.GetListWithDetails(parameters);
            var pagination = new Pagination()
            {
                CurrentPage = parameters.PageNumber,
                ItemsPerPages = parameters.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO model ,IFormFile File)
        {
            if(ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", File.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }
                model.ImageUrl = String.Concat("/images/", File.FileName);
                _manager.ProductService.CreateProduct(model);
                TempData["success"] = $"{model.ProductName} Başarılı Bir Şekilde Eklenmiştir.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int Id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.UpdateProductById(Id, false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateProductDTO model, IFormFile File)
        {
            if(ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", File.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }
                model.ImageUrl = String.Concat("/images/", File.FileName);
                _manager.ProductService.UpdateProduct(model);
                TempData["success"] = $"{model.ProductName} Başarılı Bir Şekilde Güncellenmiştir.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _manager.ProductService.DeleteProduct(id);
            TempData["success"] =  "Ürün Başarılı Bir Şekilde Silinmiştir.";

            return RedirectToAction("Index");
        }
    }
}
