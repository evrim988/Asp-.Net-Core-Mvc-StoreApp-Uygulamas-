using BLL.Abstract;
using DataAccess.Database;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(StoreAppContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders.Include(ı => ı.Lines).ThenInclude(t => t.Product).OrderBy(o => o.Shipped).ThenByDescending(d => d.Id);

        public int NumberOfInProcess => _context.Orders.Count(c => c.Shipped == false);

        public void Complete(int Id) //siparişi tamamla
        {
            var model = FindByCondition((f => f.Id == Id), true);
            if (model == null)
                throw new Exception("Sipariş Bulunamadı");
            model.Shipped = true;
            _context.SaveChanges();
        }

        public Order GetByIdOrder(int Id)
        {
            return FindByCondition((f => f.Id == Id), false);
        }

        public void SaveOrder(Order model)
        {
            _context.AttachRange(model.Lines.Select(s => s.Product));
            if (model.Id == 0)
                Create(model);
            
        }
    }
}
