using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IQueryable<Product> GetList(bool trackChanges);
        Product GetByIdProduct(int Id,bool trackChanges);
        void CreateProduct(Product model);
        void DeleteProduct(Product model);

    }

}
