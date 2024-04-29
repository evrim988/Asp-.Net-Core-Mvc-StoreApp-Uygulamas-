using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            var model = _uow.CategoryRepository.FindAll(false);
            return View(model);
        }
    }
}
