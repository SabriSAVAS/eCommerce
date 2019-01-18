using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("DiscountAppliedToCategories")]
    public partial class DiscountAppliedToCategories : BaseEntity
    {
        public int CategoryId { get; set; }
        public int DiscountId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
