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
    [Table("Customer")]
    public partial class Customer : ModelBase
    {
        public Customer()
        {
            CustomerRolMappings = new List<CustomerRolMapping>();
            CustomerAddresses = new List<CustomerAddresses>();
            ProductReviews = new List<ProductReview>();
        }
        [Required]
        public Guid CustomerGuid { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string AdminComment { get; set; }
        public bool IsActive { get; set; }
        public string LastIpAddress { get; set; }

        [ForeignKey("BillingAddress")]
        public int? BillingAddressId { get; set; }
        [ForeignKey("ShippingAddress")]
        public int? ShippingAddressId { get; set; }

        public DateTime CreatedDate
        {
            get; set;
        }
        public virtual IList<CustomerRolMapping> CustomerRolMappings { get; set; }
        public virtual IList<CustomerAddresses> CustomerAddresses { get; set; }
        public virtual IList<ProductReview> ProductReviews { get; set; }
        public virtual Address BillingAddress { get; set; }
        public virtual Address ShippingAddress { get; set; }
        
    }
}
