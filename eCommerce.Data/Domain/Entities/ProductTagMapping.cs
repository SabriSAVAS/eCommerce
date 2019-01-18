using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("Product_ProductTag_Mapping")]
    public partial class ProductTagMapping:BaseEntity
    {
        public int ProductId { get; set; }
        public int ProductTagId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductTag ProductTag { get; set; }
    }
}
