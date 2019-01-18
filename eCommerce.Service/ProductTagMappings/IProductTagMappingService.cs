using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.ProductTagMappings
{
    interface IProductTagMappingService<TEntity> where TEntity : BaseEntity
    {
    }
}
