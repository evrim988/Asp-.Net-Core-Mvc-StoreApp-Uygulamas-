using BLL.Abstract;
using DataAccess.Database;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreAppContext context) : base(context)
        {
        }

        public IQueryable<Product> GetList(bool trackChanges) => FindAll(trackChanges);

        public Product GetByIdProduct(int Id, bool trackChanges)
        {
            return FindByCondition(p => p.Id == Id, trackChanges);
        }
    }
}
