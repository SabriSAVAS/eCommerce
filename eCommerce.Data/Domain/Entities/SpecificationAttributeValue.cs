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
    [Table("SpecificationAttributeValue")]
   public class SpecificationAttributeValue:BaseEntity
    {
        public SpecificationAttributeValue()
        {
            ProductSpecificationAttributeMappings = new List<ProductSpecificationAttributeMapping>();
        }
        [Required]
        public string Name { get; set; }
        [ForeignKey("SpecificationAttribute")]
        public int SpecificationAttributeId { get; set; }
        public int OrderNo { get; set; }
        public virtual SpecificationAttribute SpecificationAttribute { get; set; }
        public virtual IList<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMappings { get; set; }
    }
}
