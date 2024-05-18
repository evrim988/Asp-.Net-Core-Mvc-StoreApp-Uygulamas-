using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.OrderService.Orders;
            return View(model);
        }

        [HttpPost]
        public IActionResult Complete([FromForm] int Id)
        {
            _manager.OrderService.Complete(Id);
            return RedirectToAction("Index");
        }
    }
}
