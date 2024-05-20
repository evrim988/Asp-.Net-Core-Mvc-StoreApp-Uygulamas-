using AutoMapper;
using BLL.Abstract;
using Entities.Dtos.Product;
using Entities.Entities;
using Entities.RequestParameters;
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
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDTO model)
        {
            var product = _mapper.Map<Product>(model);
            _unitOfWork.ProductRepository.CreateProduct(product);
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
            return _unitOfWork.ProductRepository.GetList(trackChanges).Where(s => s.IsActive == true && s.IsDeleted == false);
        }

        public IEnumerable<Product> GetListWithDetails(ProductRequestParameters model)
        {
           return _unitOfWork.ProductRepository.GetListWithDetails(model);
        }

        public Product GetProductById(int Id, bool trackChanges)
        {
            var model = _unitOfWork.ProductRepository.GetByIdProduct(Id, trackChanges);
            if (model == null)
                throw new Exception("Kayıt Bulunamadı");
            return model;
        }

        public IEnumerable<Product> GetShowCaseProducts(bool trackChanges)
        {
            var model = _unitOfWork.ProductRepository.GetShowCaseProducts(trackChanges);
            return model;
        }

        public void UpdateProduct(UpdateProductDTO model)
        {
            var models = _unitOfWork.ProductRepository.GetByIdProduct(model.Id, true);
            models.ProductName = model.ProductName;
            models.ProductDescription = model.ProductDescription;
            models.ProductPrice = model.ProductPrice;
            models.CategoryID = model.CategoryId;
            models.LastModifiedOn = DateTime.Now;
            _unitOfWork.Save();
        }

        public UpdateProductDTO UpdateProductById(int Id, bool trackChanges)
        {
            var product = _unitOfWork.ProductRepository.GetByIdProduct(Id, trackChanges);
            var productDTO = _mapper.Map<UpdateProductDTO>(product);
            return productDTO;
        }
    }
}
