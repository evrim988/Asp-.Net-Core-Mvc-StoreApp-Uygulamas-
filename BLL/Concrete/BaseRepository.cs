using BLL.Abstract;
using DataAccess.Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity,new()
    {
        protected readonly StoreAppContext _context;

        public BaseRepository(StoreAppContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.IsDeleted = false;
            entity.IsActive = true;
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            entity.DeletedOn = DateTime.Now;
            entity.IsActive = false;
            entity.IsDeleted = true;
            _context.Set<T>().Update(entity);
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
