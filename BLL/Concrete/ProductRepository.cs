using BLL.Abstract;
using BLL.Extensions;
using DataAccess.Database;
using Entities.Entities;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
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

        public void CreateProduct(Product model) => Create(model);

        public void DeleteProduct(Product model) => Delete(model);

        public IQueryable<Product> GetShowCaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges).Where(s => s.ShowCase == true);
        }

        public IQueryable<Product> GetListWithDetails(ProductRequestParameters model)
        {
            return _context
                .Products
                .FilteredByCategoryId(model.Id)
                .FilteredBySearchTerm(model.SearchTerm)
                .FilteredByPrice(model.MinPrice, model.MaxPrice, model.IsValidPrice);
        }
    }
}
