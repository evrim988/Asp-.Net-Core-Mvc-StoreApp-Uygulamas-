using Entities.Dtos.Category;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetListCategories(bool trackChanges);
        Category GetByIdCategory(int id,bool trackChanges);
        UpdateCategoryDTO UpdateCategoryById(int id, bool trackChanges);
        void CreateCategory(CategoryDTO model);
        void UpdateCategory(Category model);
        void DeleteCategory(int id);
    }
}
