using eCommerce.Data.Domain.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Data.Domain.Entities
{
    [Table("ProductAttribute")]
    public class ProductAttribute : BaseEntity
    {
        public ProductAttribute()
        {
            PredefinedProductAttributeValues = new List<PredefinedProductAttributeValue>();
            ProductAttributeMappings = new List<ProductAttributeMapping>();
          
        }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IList<PredefinedProductAttributeValue> PredefinedProductAttributeValues { get; set; }
        public virtual  List<ProductAttributeMapping> ProductAttributeMappings { get; set; }
    
    }
}
