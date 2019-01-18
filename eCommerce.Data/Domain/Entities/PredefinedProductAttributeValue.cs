using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("PredefinedProductAttributeValue")]
   public class PredefinedProductAttributeValue:BaseEntity
    {
        [ForeignKey("ProductAttribute")]
        public int ProductAttributeId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int OrderNo { get; set; }

        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
