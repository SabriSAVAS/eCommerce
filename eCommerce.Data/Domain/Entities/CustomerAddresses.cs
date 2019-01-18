using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("CustomerAddresses")]
    public class CustomerAddresses : BaseEntity
    {
        public int CustomerId { get; set; }
        public int AdressId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Address Adress { get; set; }
    }
}
