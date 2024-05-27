using Entities.Dtos.Product;
using Entities.Entities;
using Entities.RequestParameters;
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
        IEnumerable<Product> GetLastestProducts(int n, bool trackChanges);
        IEnumerable<Product> GetShowCaseProducts(bool trackChanges);
        IEnumerable<Product> GetListWithDetails(ProductRequestParameters model);

        Product GetProductById(int Id,bool trackChanges);
        UpdateProductDTO UpdateProductById(int Id, bool trackChanges);
        void CreateProduct(ProductDTO model);
        void UpdateProduct(UpdateProductDTO model);
        void DeleteProduct(int Id);
    }
}
