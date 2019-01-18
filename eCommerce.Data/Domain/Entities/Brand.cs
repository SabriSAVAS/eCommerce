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
    [Table("Brand")]
    public partial class Brand : ModelBase, IAuditableEntity
    {
        public Brand()
        {
            Products = new List<Product>();
            DiscountAppliedToBrands = new List<DiscountAppliedToBrands>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Seo { get; set; }
        public string Description { get; set; }
        [ForeignKey("Picture")]
        public int? PictureId { get; set; }
        public int OrderNo { get; set; }     
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



        public virtual Picture Picture { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual IList<DiscountAppliedToBrands> DiscountAppliedToBrands { get; set; }
    }
}
