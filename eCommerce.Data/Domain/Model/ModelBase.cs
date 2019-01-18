using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Model
{
  public  class ModelBase:BaseEntity
    {
        public ModelBase()
        {
            IsDeleted = false;
        }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
