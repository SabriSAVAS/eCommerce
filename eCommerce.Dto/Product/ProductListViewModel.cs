using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dto.Product
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public int Quantity { get; set; }
        public decimal Vat { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public bool Puhlished { get; set; }
        public bool ShowOnHomePage { get; set; }
        public bool IsFreeShipping { get; set; }
    }
}
