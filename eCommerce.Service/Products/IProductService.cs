using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.Products
{
    interface IProductService<TEntity> where TEntity:BaseEntity
    {
        
    }
}
