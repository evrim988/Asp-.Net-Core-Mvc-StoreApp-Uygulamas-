using BLL.Abstract;
using DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class,new()
    {
        protected readonly StoreAppContext _context;

        public BaseRepository(StoreAppContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();
        }

        public T FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>().Where(expression).FirstOrDefault()
                : _context.Set<T>().Where(expression).AsNoTracking().FirstOrDefault();
        }
    }
}
