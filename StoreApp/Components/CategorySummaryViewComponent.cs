using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Components
{
    public class CategorySummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategorySummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.CategoryService.GetListCategories(false).Count().ToString();
        }
    }
}
