using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("CustomerRole_Mapping")]
   public partial class CustomerRolMapping:BaseEntity
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerRole")]
        public int CustomerRoleId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
