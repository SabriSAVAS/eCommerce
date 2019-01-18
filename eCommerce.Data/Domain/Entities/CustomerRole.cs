using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("CustomerRole")]
    public class CustomerRole : BaseEntity
    {
        public CustomerRole()
        {
            CustomerRolMappings = new List<CustomerRolMapping>();
        }
        [Required]
        public string Name { get; set; }

        public IList<CustomerRolMapping> CustomerRolMappings { get; set; }
    }
}
