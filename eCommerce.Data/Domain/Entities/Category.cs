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
    [Table("Category")]
    public partial class Category : ModelBase, IAuditableEntity
    {
        public Category()
        {
            this.ProductCategoryMappings = new List<ProductCategoryMapping>();
            this.DiscountAppliedToCategories = new List<DiscountAppliedToCategories>();
            this.SubCategory = new List<Category>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Seo { get; set; }
        public string Description { get; set; }
        [ForeignKey("Picture")]
        public Nullable<int> PictureId { get; set; }
        public int ParantId { get; set; }
        public int OrderNo { get; set; }
        public bool Published { get; set; }
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
        public virtual List<Category> SubCategory { get; set; }
        public virtual IList<ProductCategoryMapping> ProductCategoryMappings { get; set; }
        public virtual IList<DiscountAppliedToCategories> DiscountAppliedToCategories { get; set; }
        public virtual Picture Picture { get; set; }

    }
}
