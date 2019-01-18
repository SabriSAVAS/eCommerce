using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dto.Brand
{
   public class BrandListViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string PicturePath { get; set; }
        public int OrderNo { get; set; }
    }
}
