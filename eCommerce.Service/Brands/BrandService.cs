using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Data.Domain.Entities;
using eCommerce.Data.UnitOfWork;

namespace eCommerce.Service.Brands
{
    public class BrandService :BaseService<Brand>, IBrandService<Brand>
    {
        
    }
}
