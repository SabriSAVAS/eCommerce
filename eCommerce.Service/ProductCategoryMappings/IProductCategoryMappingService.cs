﻿using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Service.ProductCategoryMappings
{
    interface IProductCategoryMappingService<TEntity>where TEntity:BaseEntity
    {
    }
}
