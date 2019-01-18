using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("Discount")]
    public partial class Discount : ModelBase, IAuditableEntity
    {
        public Discount()
        {
            DiscountAppliedToCategories = new List<DiscountAppliedToCategories>();
            DiscountAppliedToProducts = new List<DiscountAppliedToProducts>();
            DiscountAppliedToBrands = new List<DiscountAppliedToBrands>();
            DiscountUsageHistorys = new List<DiscountUsageHistory>();
        }
        [Required]
        public string Name { get; set; }
        public int DiscountTypeId { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        [Required]
        public bool RequiresCouponCode { get; set; }
        public string CouponCode { get; set; }
        
        public int CreatedById
        {
            get; set;
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

        public virtual IList<DiscountAppliedToCategories> DiscountAppliedToCategories { get; set; }
        public virtual IList<DiscountAppliedToProducts> DiscountAppliedToProducts { get; set; }
        public virtual IList<DiscountAppliedToBrands> DiscountAppliedToBrands { get; set; }
        public virtual IList<DiscountUsageHistory> DiscountUsageHistorys { get; set; }
    }
}
