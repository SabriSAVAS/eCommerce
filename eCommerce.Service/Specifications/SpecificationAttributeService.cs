using eCommerce.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using eCommerce.Data.UnitOfWork;

namespace eCommerce.Service.Specifications
{
    public class SpecificationAttributeService :BaseService<SpecificationAttribute>, ISpecificationAttribute<SpecificationAttribute>
    {
      
    }
}
