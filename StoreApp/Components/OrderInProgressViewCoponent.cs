using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Components
{
    public class OrderInProgressViewCoponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public OrderInProgressViewCoponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.OrderService.NumberOfInProcess.ToString();
        }
    }
}
