using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("Order")]
    public partial class Order : ModelBase, IAuditableEntity
    {
        public Order()
        {
            DiscountUsageHistorys = new List<DiscountUsageHistory>();
        }

        public Guid OrderGuid { get; set; }

        public int CreatedById
        {
            get;set;
        }

        public DateTime CreatedDate
        {
            get; set;
        }

        public int? UpdatedById
        {
            get; set;
        }

        public DateTime? UpdatedDate
        {
            get; set;
        }
        public virtual IList<DiscountUsageHistory> DiscountUsageHistorys { get; set; }
    }
}
