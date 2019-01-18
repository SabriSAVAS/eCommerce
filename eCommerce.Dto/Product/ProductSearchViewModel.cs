using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Web.Mvc;

namespace eCommerce.Dto.Product
{
  public  class ProductSearchViewModel
    {
        public ProductSearchViewModel()
        {
            CategoryList = new List<SelectListItem>();
            BrandList = new List<SelectListItem>();
            Puhlished = true;
        }
        public string ProductName { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> BrandList { get; set; }
        public int BrandId { get; set; }
        public bool Puhlished { get; set; }
        public int? Page { get; set; }
        public IPagedList<ProductListViewModel> ProductList { get; set; }
    }
}
