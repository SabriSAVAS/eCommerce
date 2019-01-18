using eCommerce.Data.Domain.Entities;
using eCommerce.Dto.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Areas.Management.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Management/Customer
        public ActionResult Index()
        {
         return RedirectToAction("Customer", "List");
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Create()
        {
            var model = new CustomerViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                DateTime DateOfBirth = Convert.ToDateTime(model.DateofBirth);
                Customer customer = new Customer();
                customer.Email = model.Email;
                customer.CustomerGuid = Guid.NewGuid();
                customer.UserName = model.UserName;
                customer.Password = model.Password;
                customer.LastIpAddress = "";
                customer.CreatedDate = DateTime.Now;
                customer.BillingAddressId =null;
                customer.ShippingAddressId =null;
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.DateOfBirth = DateOfBirth;
                customer.IsActive = model.IsActive;
                customer.CompanyName = model.CompanyName;
                customer.AdminComment = model.AdminComment;
                customer.Gender = model.Gender;
                if (_customerService.Insert(customer)!=null)
                {
                    if (model.CustomerRoleId.Count > 0)
                    {
                        foreach (var item in model.CustomerRoleId)
                        {
                            CustomerRolMapping rolmap = new CustomerRolMapping();
                            rolmap.CustomerId = customer.Id;
                            rolmap.CustomerRoleId = item;

                            _customerRoleMappingService.Insert(rolmap);
                        }

                    }
                    Success("Kayit işlemi başarılı");
                    return RedirectToAction("List");
                }
                else
                {
                    Warning("Kayit işlemi başarısız");
                    return RedirectToAction("List");
                }
              
            }
            return View(model);
        }


    }
}