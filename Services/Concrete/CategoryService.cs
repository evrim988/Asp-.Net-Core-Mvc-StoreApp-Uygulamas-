using BLL.Abstract;
using DataAccess.Database;
using Entities.Entities;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCategory(Category model)
        {
            _unitOfWork.CategoryRepository.Create(model);
            _unitOfWork.Save();
        }

        public void DeleteCategory(int id)
        {
            var model = _unitOfWork.CategoryRepository.GetByIdCategory(id, false);
            if(model  != null)
            {
                _unitOfWork.CategoryRepository.DeleteCategory(model);
                _unitOfWork.Save();
            }
        }

        public Category GetByIdCategory(int id, bool trackChanges)
        {
            var model = _unitOfWork.CategoryRepository.GetByIdCategory(id, trackChanges);
            if (model == null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            return model;
        }

        public IEnumerable<Category> GetListCategories(bool trackChanges)
        {
            return _unitOfWork.CategoryRepository.FindAll(trackChanges).Where(s => s.IsDeleted == false && s.IsActive == true);
        }

        public void UpdateCategory(Category model)
        {
            var models = _unitOfWork.CategoryRepository.GetByIdCategory(model.Id, true);
            models.CategoryName = model.CategoryName;
            models.CategoryDescription = model.CategoryDescription;
            models.LastModifiedOn = DateTime.Now;
            _unitOfWork.Save();
        }
    }
}
