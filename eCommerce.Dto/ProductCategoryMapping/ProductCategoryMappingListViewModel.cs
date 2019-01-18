using eCommerce.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dto.ProductCategoryMapping
{
    public class ProductCategoryMappingListViewModel
    {
        public ProductCategoryMappingListViewModel()
        {
            Category = new CategoryListViewModel();
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public CategoryListViewModel Category { get; set; }
    }
}
