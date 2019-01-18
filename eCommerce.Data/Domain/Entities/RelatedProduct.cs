using eCommerce.Data.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Data.Domain.Entities
{
    [Table("RelatedProduct")]
    public class RelatedProduct:BaseEntity
    {
        [Required]
        public int ProductId1 { get; set; }
        [Required]
        public int ProductId2 { get; set; }
        public int OrderNo { get; set; }

    }
}
