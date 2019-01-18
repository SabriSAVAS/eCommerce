using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("Product_Picture_Mapping")]
    public partial class ProductPictureMapping : BaseEntity
    {
        public int ProductId { get; set; }
        public int PictureId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
