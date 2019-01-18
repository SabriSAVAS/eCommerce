using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("DiscountUsageHistory")]
    public class DiscountUsageHistory : BaseEntity
    {
        public int DiscountId { get; set; }
        public int OrderId { get; set; }
        public virtual  Discount Discount { get; set; }
        public virtual  Order Order { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
