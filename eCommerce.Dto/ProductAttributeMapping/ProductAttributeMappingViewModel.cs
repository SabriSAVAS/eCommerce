using eCommerce.Dto.Enums;
using System.Collections.Generic;
using System.Web.Mvc;
namespace eCommerce.Dto.ProductAttributeMapping
{
    public  class ProductAttributeMappingViewModel
    {
        public ProductAttributeMappingViewModel()
        {
            
            ProductAttribute = new List<SelectListItem>();
            AttributeControlType = AttributeControlType.DropdownList;
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public List<SelectListItem> ProductAttribute { get; set; }
        public int AttributeControlTypeId { get; set; }
        public AttributeControlType AttributeControlType { get; set; }
        public string TextPrompt { get; set; }
    }
}
