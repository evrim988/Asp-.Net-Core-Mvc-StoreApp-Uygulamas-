using BLL.Abstract;
using DataAccess.Database;
using Entities;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using StoreApp.Models;

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

        public IActionResult GetProducts([FromRoute(Name = "Id")]int Id)
        {
            var model = _manager.ProductService.GetProductById(Id, false);
            return View(model);
        }

    }
}
