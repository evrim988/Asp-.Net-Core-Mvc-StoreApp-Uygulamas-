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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateProduct(Product model)
        {
            _unitOfWork.ProductRepository.CreateProduct(model);
            _unitOfWork.Save();
        }

        public void DeleteProduct(int Id)
        {
            var model = GetProductById(Id, false);
            if (model != null)
            {
                _unitOfWork.ProductRepository.DeleteProduct(model);
                _unitOfWork.Save();
            }
        }
        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _unitOfWork.ProductRepository.GetList(trackChanges).Where(s=> s.IsActive == true && s.IsDeleted == false);
        }

        public Product GetProductById(int Id, bool trackChanges)
        {
            var model = _unitOfWork.ProductRepository.GetByIdProduct(Id, trackChanges);
            if (model == null)
                throw new Exception("Kayıt Bulunamadı");
            return model;
        }

        public void UpdateProduct(Product model)
        {
            var models = _unitOfWork.ProductRepository.GetByIdProduct(model.Id, true);
            models.ProductName = model.ProductName;
            models.ProductDescription = model.ProductDescription;
            models.ProductPrice = model.ProductPrice;
            models.LastModifiedOn = DateTime.Now;
            _unitOfWork.Save();
        }
    }
}
