using BLL.Abstract;
using DataAccess.Database;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false); //değişiklikleri izleyip izlemediğini sorguluyor.
            return View(model);
        }

        public IActionResult GetProducts([FromRoute(Name = "id")]int Id)
        {
            var model = _manager.ProductService.GetProductById(Id, false);
            return View(model);
        }

    }
}
