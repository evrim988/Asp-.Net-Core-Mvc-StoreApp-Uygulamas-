using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Components
{
    public class ShowCaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ShowCaseViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var model = _manager.ProductService.GetShowCaseProducts(false);
            return View(model);
        }
    }
}
