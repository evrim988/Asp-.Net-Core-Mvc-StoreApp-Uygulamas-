using BLL.Abstract;
using DataAccess.Database;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var model = _unitOfWork.ProductRepository.GetList(false); //değişiklikleri izleyip izlemediğini sorguluyor.
            return View(model);
        }

        public IActionResult GetProducts(int Id)
        {
            var model = _unitOfWork.ProductRepository.GetByIdProduct(Id, false);
            return View(model);
        }

    }
}
