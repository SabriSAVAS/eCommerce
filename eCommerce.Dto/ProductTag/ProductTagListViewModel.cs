using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dto.ProductTag
{
   public class ProductTagListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Taggedproducts { get; set; }
    }
}
