using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("DiscountAppliedToBrands")]
    public partial class DiscountAppliedToBrands:BaseEntity
    {
        public int BrandId { get; set; }
        public int DiscountId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
