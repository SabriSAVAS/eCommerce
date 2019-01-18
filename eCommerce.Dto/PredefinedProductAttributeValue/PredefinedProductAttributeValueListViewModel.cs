using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dto.PredefinedProductAttributeValue
{
   public class PredefinedProductAttributeValueListViewModel
    {
        public int Id { get; set; }
        public int ProductAttributeId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int OrderNo { get; set; }
    }
}
