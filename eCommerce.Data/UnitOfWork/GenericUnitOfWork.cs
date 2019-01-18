using eCommerce.Data.Domain.Context;
using eCommerce.Data.Domain.Model;
using eCommerce.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.UnitOfWork
{
    public class GenericUnitOfWork : IDisposable
    {
        private eCommerceContext _context;
        string errorMessage;
        public GenericUnitOfWork()
        {
            _context = new eCommerceContext();
        }
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IRepository<TEntity>;
            }
            IRepository<TEntity> _repository = new GenericRepository<TEntity>(_context);
            repositories.Add(typeof(TEntity), _repository);
            return _repository;
        }
        public bool SaveChanges()
        {
            try
            {
                if (_context.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationMessages in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationMessages.ValidationErrors)
                    {
                       errorMessage += Environment.NewLine + string.Format("Property : {0} Error : {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(errorMessage, ex);
                //return false;
            }
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
