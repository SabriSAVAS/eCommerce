using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    public partial class ProductTag : BaseEntity
    {
        public ProductTag()
        {
            ProductTagMappings = new List<ProductTagMapping>();
        }
        public string Name { get; set; }
        public virtual IList<ProductTagMapping> ProductTagMappings { get; set; }
    }
}
