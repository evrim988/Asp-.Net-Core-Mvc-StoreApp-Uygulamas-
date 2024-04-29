using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        T FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges); //idsine göre getir gibi benzeri bir method
    }
}
