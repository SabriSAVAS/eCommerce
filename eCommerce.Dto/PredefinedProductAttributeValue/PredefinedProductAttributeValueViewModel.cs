using System.ComponentModel.DataAnnotations;

namespace eCommerce.Dto.PredefinedProductAttributeValue
{
    public  class PredefinedProductAttributeValueViewModel
    {
        public int Id { get; set; }
        [Required]
        public int ProductAttributeId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int OrderNo { get; set; }

    }
}
