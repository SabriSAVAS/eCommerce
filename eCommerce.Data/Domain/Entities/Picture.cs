using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("Picture")]
    public partial class Picture : BaseEntity
    {
        public Picture()
        {
            this.Brands = new List<Brand>();
            this.ProductPictureMappings = new List<ProductPictureMapping>();
            this.Categorys = new List<Category>();
        }
        public string Title { get; set; }
        public string Alt { get; set; }
        public string SmallPath { get; set; }
        public string Default { get; set; }
        public int? OrderNo { get; set; }
        public virtual IList<Brand> Brands { get; set; }
        public virtual IList<ProductPictureMapping> ProductPictureMappings { get; set; }
        public virtual IList<Category> Categorys { get; set; }
    }
}
