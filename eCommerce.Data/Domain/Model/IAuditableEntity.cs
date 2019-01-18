using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Model
{
    interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }

        int CreatedById { get; set; }

        DateTime? UpdatedDate { get; set; }

        int? UpdatedById { get; set; }
    }
}
