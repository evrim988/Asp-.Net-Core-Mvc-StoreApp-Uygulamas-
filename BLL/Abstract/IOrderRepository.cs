using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        IQueryable<Order> Orders { get; }

        Order GetByIdOrder(int Id);

        void Complete(int Id);

        void SaveOrder(Order model);

        int NumberOfInProcess {  get; }
    }
}
