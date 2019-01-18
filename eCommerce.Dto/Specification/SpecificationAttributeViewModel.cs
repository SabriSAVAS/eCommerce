using eCommerce.Dto.SpecificationValue;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dto.Specification
{
    public class SpecificationAttributeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int OrderNo { get; set; }

        //public SpecificationAttributeValueViewModel SpecificationAttributeValue { get; set; }
    }
}
