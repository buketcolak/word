using System;
using System.Linq;
using System.Linq.Expressions;

namespace WordSaver.Business.Data
{
    public interface IRepository<T>
           where T : BaseEntity
    {
        T Create(T entity);
        T Update(T entity);

        void Delete(int id);
        void Delete(Expression<Func<T, bool>> where);

        T FindOne(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindAll(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includeProperties);

        bool Any(Expression<Func<T, bool>> where);
        int Count(Expression<Func<T, bool>> where);
        int Sum(Expression<Func<T, int>> where);

        bool SaveChanges();
    }
}