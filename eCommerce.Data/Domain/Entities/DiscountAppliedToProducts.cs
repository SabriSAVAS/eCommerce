using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("DiscountAppliedToProducts")]
    public partial class DiscountAppliedToProducts : BaseEntity
    {
        public int ProductId { get; set; }
        public int DiscountId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Discount Discount { get; set; }


    }
}
