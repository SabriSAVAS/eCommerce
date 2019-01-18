using eCommerce.Service.ProductTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using eCommerce.Dto.ProductTag;
using eCommerce.Data.Domain.Entities;
using eCommerce.Service.ProductTagMappings;

namespace eCommerce.UI.Areas.Management.Controllers
{
    public class ProductTagController : Controller
    {
        ProductTagService _productTagService;
        ProductTagMappingService _productTagMappingService;
        public ProductTagController()
        {
            _productTagMappingService = new ProductTagMappingService();
            _productTagService = new ProductTagService();
        }
        // GET: Management/ProductTag
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult List(int? Page)
        {
            int pageIndex = Page ?? 1;

            var tags = _productTagService.GetList();
            List<ProductTagListViewModel> list = new List<ProductTagListViewModel>();
            foreach (var item in tags)
            {
                ProductTagListViewModel tag = new ProductTagListViewModel();
                tag.Id = item.Id;
                tag.Name = item.Name.ToLower().Trim();
                tag.Taggedproducts = item.ProductTagMappings.Count;
                list.Add(tag);
            }
            var model = list.ToPagedList(pageIndex,20);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_TagList", model);
            }
            return View(model);
        }

        public PartialViewResult _TagEditPopup()
        {
            ProductTagViewModel model = new ProductTagViewModel();

            return PartialView(model);
        }
        public JsonResult Edit(int Id)
        {

            var data = _productTagService.GetById(Id);
            var tag = new ProductTagViewModel();
            tag.Id = data.Id;
            tag.Name = data.Name;
          
            return Json(tag, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Edit(ProductTagViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProductTag _tag = new ProductTag();
                _tag.Id = model.Id;
                _tag.Name = model.Name;
            
                if (_productTagService.Update(_tag))
                    return "1";
                return "-1";
            }
            return "-1";
        }
        [HttpPost]
        public string Delete(int Id)
        {
            if (Id > 0)
            {
                var mappping = _productTagMappingService.GetList(x => x.ProductTagId == Id).ToList();

                if (mappping.Count>0)
                {
                    if (_productTagMappingService.Delete(mappping))
                    {
                        if (_productTagService.Delete(Id))
                            return "1";
                        else
                            return "-1";
                    }

                }
                else
                {
                    if (_productTagService.Delete(Id))
                        return "1";
                    else
                        return "-1";
                }

            }
            return "-1";
        }
        //protected override void Dispose(bool disposing)
        //{
        //    _productTagMappingService._unit.Dispose(true);
        //    _productTagService._unit.Dispose(true);
        //}
    }
}