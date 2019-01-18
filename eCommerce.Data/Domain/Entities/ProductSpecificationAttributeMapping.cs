using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("Product_SpecificationAttribute_Mapping")]
    public class ProductSpecificationAttributeMapping:BaseEntity
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int AttributeTypeId { get; set; }
        [ForeignKey("SpecificationAttributeValue")]
        public int SpecificationAttributeValueId { get; set; }
        public string CustomValue { get; set; }
        public bool ShowOnProductPage { get; set; }

        public virtual Product Product { get; set; }

        public virtual SpecificationAttributeValue SpecificationAttributeValue { get; set; }
    }
}
