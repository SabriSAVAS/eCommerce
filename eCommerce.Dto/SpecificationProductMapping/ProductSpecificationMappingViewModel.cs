using eCommerce.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eCommerce.Dto.SpecificationProductMapping
{
 public class ProductSpecificationMappingViewModel
    {
        public ProductSpecificationMappingViewModel()
        {
            SpecificationAttributeType = new SpecificationAttributeType();
            SpecificationAttributeValue = new List<SelectListItem>();
            SpecificationAttribute = new List<SelectListItem>();
            ShowOnProductPage = true;
        }
        //Specification Attribute
        public int AttributeTypeId { get; set; }
        public SpecificationAttributeType SpecificationAttributeType { get; set; }
        public int SpecificationAttributeId { get; set; }
        public List<SelectListItem> SpecificationAttribute { get; set; }
        public int SpecificationAttributeValueId { get; set; }
        public List<SelectListItem> SpecificationAttributeValue { get; set; }
        public string CustomValue { get; set; }
        public bool ShowOnProductPage { get; set; }

    }
}
