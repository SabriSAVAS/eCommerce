using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service
{
    interface IBaseService<TEntity> where TEntity:BaseEntity
    {
        IList<TEntity> GetList();
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> where);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        bool Any(Expression<Func<TEntity, bool>> where);
        TEntity GetById(int Id);
        TEntity Insert(TEntity Entity);
        bool Update(TEntity Entity);
        bool Delete(int Id);
        bool Delete(TEntity Entity);
        bool Delete(List<TEntity> Entity);
    }
}
