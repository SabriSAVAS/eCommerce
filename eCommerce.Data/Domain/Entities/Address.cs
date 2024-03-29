﻿using eCommerce.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Entities
{
    [Table("Address")]
    public partial class Address : BaseEntity
    {
        public Address()
        {
            CustomerAddresses = new List<CustomerAddresses>();
        }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [ForeignKey("StateProvince")]
        public int StateProvinceId { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual IList<CustomerAddresses> CustomerAddresses { get; set; }
        public virtual Country Country { get; set; }
        public virtual  StateProvince StateProvince { get; set; }
    }
}
