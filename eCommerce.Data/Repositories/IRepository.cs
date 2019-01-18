using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Repositories
{
   public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IList<TEntity> GetList();
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> where);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        bool Any(Expression<Func<TEntity, bool>> where);
        TEntity GetById(int Id);
        TEntity Insert(TEntity Entity);       
        void Update(TEntity Entity);
        void Delete(int Id);
        void Delete(TEntity Entity);
        void Delete(List<TEntity> Entity);

    }
}
