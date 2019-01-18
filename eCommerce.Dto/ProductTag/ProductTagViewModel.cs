using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dto.ProductTag
{
  public  class ProductTagViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Taggedproducts { get; set; }
    }
}
