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

        public IViewComponentResult Invoke(string page = "default")
        {
            var model = _manager.ProductService.GetShowCaseProducts(false);
            return page == "default" ? View(model) : View("List", model);
        }
    }
}
