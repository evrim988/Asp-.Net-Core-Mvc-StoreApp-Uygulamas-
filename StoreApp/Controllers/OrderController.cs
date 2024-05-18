using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Cart _cart;

        public OrderController(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            _cart = cart;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] Order model)
        {
            if (_cart.Lines.Count() == 0)
                ModelState.AddModelError("", "Sepetiniz Boş Sipariş Oluşturamazsınız.");

            else {
                model.Lines = _cart.Lines.ToArray();
                _manager.OrderService.SaveOrder(model);
                _cart.Clear();
                return RedirectToPage("/Complete", new { orderId = model.Id });
            }

            return View();

        }
    }
}
