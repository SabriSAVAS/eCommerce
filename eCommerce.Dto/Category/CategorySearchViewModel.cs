using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace eCommerce.Dto.Category
{
   public class CategorySearchViewModel
    {
        public string CategoryName { get; set; }
        public int? Page { get; set; }
        public IPagedList<CategoryListViewModel> CategoryList { get; set; }
    }
}
