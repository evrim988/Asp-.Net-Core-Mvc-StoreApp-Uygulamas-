using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product GetProductById(int Id,bool trackChanges);
        void CreateProduct(Product model);
        void UpdateProduct(Product model);
        void DeleteProduct(int Id);
    }
}
