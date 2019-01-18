using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("StateProvince")]
    public class StateProvince : BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public bool Published { get; set; }
        public virtual Country Country { get; set; }
    }
}
