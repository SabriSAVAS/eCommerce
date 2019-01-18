using eCommerce.Data.Domain.Model;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Data.Domain.Entities
{
    public partial class SpecificationAttribute : BaseEntity
    {
        public SpecificationAttribute()
        {
            SpecificationAttributeValues = new List<SpecificationAttributeValue>();
        }
        [Required]
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public virtual IList<SpecificationAttributeValue> SpecificationAttributeValues { get; set; }
    }
}
