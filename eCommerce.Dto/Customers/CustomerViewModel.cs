using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eCommerce.Dto.Customers
{
  public  class CustomerViewModel
    {
        public CustomerViewModel()
        {
            IsActive = true;
            CustomerRoleList = new List<SelectListItem>();
            CustomerRoleList.Add(new SelectListItem { Text = "Administrators", Value = "1" });
            CustomerRoleList.Add(new SelectListItem { Text = "Guests", Value = "2" });
            CustomerRoleList.Add(new SelectListItem { Text = "Owner", Value = "3" });
            DateofBirth=DateTime.Now.ToString("dd/MM/yyyy");

        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<int> CustomerRoleId { get; set; }
        public List<SelectListItem> CustomerRoleList { get; set; }
        public bool  Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateofBirth { get; set; }
        public string CompanyName { get; set; }
        public string AdminComment { get; set; }
        public bool IsActive { get; set; }
      
    }
}
