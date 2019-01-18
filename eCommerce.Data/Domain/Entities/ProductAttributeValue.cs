using eCommerce.Data.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Data.Domain.Entities
{
    [Table("ProductAttributeValue")]
    public partial class ProductAttributeValue : BaseEntity
    {
        [ForeignKey("ProductAttributeMapping")]
        public int ProductAttributeMappingId { get; set; }
        public int AttributeValueTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public int OrderNo { get; set; }

        public virtual ProductAttributeMapping ProductAttributeMapping { get; set; }

    }
}
