using BLL.Abstract;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreAppContext _context;

        public UnitOfWork(StoreAppContext context)
        {
            _context = context;
        }

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository 
        {
            get => _productRepository ?? (_productRepository = new ProductRepository(_context));
        }

        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get => _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context));
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
