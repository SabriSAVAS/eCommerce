using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dto.Picture
{
   public class PictureListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Alt { get; set; }
        public string SmallPath { get; set; }
        public string Default { get; set; }
        public int? OrderNo { get; set; }
    }
}
