using System.ComponentModel.DataAnnotations;

namespace eCommerce.Dto.ProductAttributeValue
{
    public class ProductAttributeValueViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int ProductAttributeId { get; set; }
        [Required]        
        public decimal Cost { get; set; }
        [Required]
        public int OrderNo { get; set; }
    }
}
