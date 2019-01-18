using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dto.Category
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public string Seo { get; set; }
        public string Description { get; set; }
   
        public Nullable<int> PictureId { get; set; }
        public int ParantId { get; set; }
        public int OrderNo { get; set; }
        public bool Published { get; set; }
        public int CreatedById
        {
            get; set;
        }

        public DateTime CreatedDate
        {
            get; set;
        }

        public int? UpdatedById
        {
            get; set;
        }

        public DateTime? UpdatedDate
        {
            get; set;
        }


    }
}
