using BLL.Abstract;
using DataAccess.Database;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(StoreAppContext context) : base(context)
    {
    }

    public void CreateCategory(Category model) => Create(model);

    public void DeleteCategory(Category model) => Delete(model);

    public Category GetByIdCategory(int Id, bool trackChanges)
    {
        return FindByCondition(f => f.Id == Id, trackChanges);
    }
}
