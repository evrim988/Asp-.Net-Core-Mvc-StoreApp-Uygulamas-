using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract;

public interface ICategoryRepository : IBaseRepository<Category>
{
    void CreateCategory(Category model);
    void DeleteCategory(Category model);
    Category GetByIdCategory(int Id,bool trackChanges);
}
