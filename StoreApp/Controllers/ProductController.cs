using BLL.Abstract;
using DataAccess.Database;
using Entities;
using Entities.RequestParameters;
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
        public IActionResult Index(ProductRequestParameters parameters)
        {
            var model = _manager.ProductService.GetListWithDetails(parameters); 
            return View(model);
        }

        public IActionResult GetProducts([FromRoute(Name = "Id")]int Id)
        {
            var model = _manager.ProductService.GetProductById(Id, false);
            return View(model);
        }

    }
}
