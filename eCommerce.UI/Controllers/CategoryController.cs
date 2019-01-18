using eCommerce.Data.Domain.Entities;
using eCommerce.Service.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService _categoryservice;
        public CategoryController()
        {
            _categoryservice = new CategoryService();
        }
        public ActionResult Index()
        {
            List<Category> allcategory = _categoryservice.GetList().ToList();
            //var subcategory = allcategory.FirstOrDefault(x => x.ParantId == 0);
            //LoadChidren(subcategory,allcategory);
            return View(allcategory);
        }

        private void LoadChidren(Category subcategory, List<Category> allcategory)
        {
            subcategory.SubCategory = allcategory.Where(x => x.ParantId == subcategory.Id).ToList();
            foreach (var item in subcategory.SubCategory)
            {
                LoadChidren(item, allcategory);
            }
        }
    }
}