using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dto.SpecificationProductMapping
{
  public  class ProductSpecificationMappingListViewModel
    {
        public int Id { get; set; }
        public int AttributeTypeId { get; set; }    
        public string  SpecificationAttribute { get; set; }      
        public string SpecificationAttributeValue { get; set; }  
        public string CustomValue { get; set; }
        public bool ShowOnProductPage { get; set; }
    }
}
