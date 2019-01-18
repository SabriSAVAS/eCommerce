using System.ComponentModel.DataAnnotations;

namespace eCommerce.Dto.SpecificationValue
{
    public  class SpecificationAttributeValueViewModel
    {
        public int ValueId { get; set; }
        [Required]
        public string Name { get; set; }
        public int SpecificationAttributeId { get; set; }
        public int OrderNo { get; set; }
    }
}
