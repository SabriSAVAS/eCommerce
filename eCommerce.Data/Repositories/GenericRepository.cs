using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using eCommerce.Data.Domain.Context;
using System.Data.Entity;

namespace eCommerce.Data.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private eCommerceContext _context;
        public GenericRepository(eCommerceContext context)
        {
            _context = context;
        }
        public eCommerceContext Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().Any(where);
        }

        public virtual void Delete(List<TEntity> Entity)
        {
            _context.Set<TEntity>().RemoveRange(Entity);
        }

        public virtual void Delete(TEntity Entity)
        {
            _context.Set<TEntity>().Remove(Entity);
        }

        public virtual void Delete(int Id)
        {
            var entity = GetById(Id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().Where(where).FirstOrDefault();
        }

        public virtual TEntity GetById(int Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        public virtual IList<TEntity> GetList()
        {
            return _context.Set<TEntity>().OrderByDescending(x => x.Id).ToList();
        }

        public virtual IList<TEntity> GetList(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().Where(where).OrderByDescending(x => x.Id).ToList();
        }

        public virtual TEntity Insert(TEntity Entity)
        {
            return _context.Set<TEntity>().Add(Entity);
        }

        public virtual void Update(TEntity Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
        }
   
    }
}
