using eCommerce.Data.Domain.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Data.Domain.Entities
{
    [Table("Product_ProductAttribute_Mapping")]
    public partial class ProductAttributeMapping : BaseEntity
    {
        public ProductAttributeMapping()
        {
            ProductAttributeValues = new List<ProductAttributeValue>();
        }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductAttribute")]
        public int ProductAttributeId { get; set; }
        public int AttributeControlTypeId { get; set; }
        public string TextPrompt { get; set; }

        public virtual ProductAttribute ProductAttribute { get; set; }
        public virtual Product Product { get; set; }
        public virtual IList<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}
