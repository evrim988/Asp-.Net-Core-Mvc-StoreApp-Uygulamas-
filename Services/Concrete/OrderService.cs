using BLL.Abstract;
using Entities.Entities;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;

        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<Order> Orders => _uow.OrderRepository.Orders;

        public int NumberOfInProcess => _uow.OrderRepository.NumberOfInProcess;

        public void Complete(int Id)
        {
            _uow.OrderRepository.Complete(Id);
            _uow.Save();
        }

        public Order GetByIdOrder(int Id)
        {
           return _uow.OrderRepository.GetByIdOrder(Id);
        }

        public void SaveOrder(Order model)
        {
            _uow.OrderRepository.SaveOrder(model);
            _uow.Save();
        }
    }
}
