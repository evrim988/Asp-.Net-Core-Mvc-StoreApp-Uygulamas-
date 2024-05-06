using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoriesMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var model = _manager.CategoryService.GetListCategories(false);
            return View(model);
        }
    }
}
