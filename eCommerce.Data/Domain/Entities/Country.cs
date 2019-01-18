using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("Country")]
    public class Country : BaseEntity
    {
        public Country()
        {
            StateProvinces = new List<StateProvince>();
        }
        public string Name { get; set; }
        public bool Published { get; set; }
        public virtual IList<StateProvince> StateProvinces { get; set; }

    }
}
