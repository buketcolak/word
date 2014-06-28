using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace WordSaver.Business.Data
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
         where TEntity : BaseEntity
    {
        protected WordDBContext Context;

        public Repository()
        {
            Context = new WordDBContext();
        }

        public virtual TEntity Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(int id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            var objects = Context.Set<TEntity>().Where(where).AsEnumerable();
            foreach (var item in objects)
            {
                Context.Set<TEntity>().Remove(item);
                Context.Entry(item).State = EntityState.Deleted;
            }
        }

        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FindAll(where, includeProperties).FirstOrDefault();
        }

        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var items = where != null
                ? Context.Set<TEntity>().Where(where)
                : Context.Set<TEntity>();

            foreach (var property in includeProperties)
            {
                items.Include(property);
            }

            return items;
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> where)
        {
            return Context.Set<TEntity>().Any(where);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> where)
        {
            return Context.Set<TEntity>().Count(where);
        }

        public virtual int Sum(Expression<Func<TEntity, int>> where)
        {
            return Context.Set<TEntity>().Sum(where);
        }

        public virtual bool SaveChanges()
        {
            return 0 < Context.SaveChanges();
        }

        public void Dispose()
        {
            if (null != Context)
            {
                Context.Dispose();
            }
        }
    }
}