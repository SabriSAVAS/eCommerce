using eCommerce.Data.Domain.Entities;
using eCommerce.Dto.ProductAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using eCommerce.Dto.ProductAttributeValue;
using eCommerce.Dto.PredefinedProductAttributeValue;

namespace eCommerce.UI.Areas.Management.Controllers
{
    public class ProductAttributeController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("List", "ProductAttribute");
        }

        public ActionResult List(int? Page)
        {
            int pageIndex = Page ?? 1;

            var data = _productAttributeService.GetList();
            List<ProductAttributeListViewModel> list = new List<ProductAttributeListViewModel>();
            foreach (var item in data)
            {
                ProductAttributeListViewModel _pro = new ProductAttributeListViewModel();
                _pro.Description = item.Description;
                _pro.Id = item.Id;
                _pro.Name = item.Name;
                list.Add(_pro);
            }
            var model = list.ToPagedList(pageIndex, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductAttributeList", model);
            }
            return View(model);
        }
        public ActionResult Create()
        {
            var model = new ProductAttributeViewModel();
            return View(model);
        }
        [HttpPost, ParameterBasedOnFormName("savecontiune", "continueEditing")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductAttributeViewModel model, bool continueEditing)
        {

            if (ModelState.IsValid)
            {

                ProductAttribute _pro = new ProductAttribute();
                _pro.Name = model.Name;
                _pro.Description = model.Description;

                if (_productAttributeService.Insert(_pro) != null)
                    Success("Kayit işlemi başarılı bir şekilde gerçekleşti");
                else
                    Danger("Kayıt işlemi sirasında bir hata gerçekleşti");
                if (continueEditing)
                {
                    return RedirectToAction("Edit", "ProductAttribute", new { Id = _pro.Id });
                }
                return RedirectToAction("List", "ProductAttribute");
            }
            return View(model);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return RedirectToAction("List", "ProductAttribute");
            var model = new ProductAttributeViewModel();
            if (Id > 0)
            {
                var data = _productAttributeService.GetById(Id ?? 0);
                model.Id = data.Id;
                model.Name = data.Name;
                model.Description = data.Description;
            }
            return View(model);
        }
        [HttpPost, ParameterBasedOnFormName("savecontiune", "continueEditing")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductAttributeViewModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                ProductAttribute _pro = new ProductAttribute();
                _pro.Id = model.Id;
                _pro.Name = model.Name;
                _pro.Description = model.Description;
                if (_productAttributeService.Update(_pro))
                    Success("Kayit işlemi başarılı bir şekilde gerçekleşti");
                else
                    Danger("Kayıt işlemi sirasında bir hata gerçekleşti");
                if (continueEditing)
                {
                    return RedirectToAction("Edit", "ProductAttribute", new { Id = model.Id });
                }
                return RedirectToAction("List", "ProductAttribute");
            }
            return View(model);
        }
        [HttpPost]
        public string Delete(int Id)
        {
            if (Id == 0) throw new ArgumentException("ValueByAttribute Id degeri >>" + Id);
            var value = _predefinedProductAttributeValueService.GetList(x => x.ProductAttributeId == Id).ToList();
            if (value != null)
            {
                if (_predefinedProductAttributeValueService.Delete(value))
                {
                    if (_productAttributeService.Delete(Id))
                    {
                        return "1";
                    }
                    else
                    {
                        return "-1";
                    }
                }
            }
            else
            {
                if (_productAttributeService.Delete(Id))
                    return "1";
                return "-1";
            }

            return "-1";
        }


        public PartialViewResult _ProductAttributeValueList(int Id)
        {
            var data = _predefinedProductAttributeValueService.GetList(x => x.ProductAttributeId == Id);
            List<PredefinedProductAttributeValueListViewModel> list = new List<PredefinedProductAttributeValueListViewModel>();
            foreach (var item in data)
            {
                PredefinedProductAttributeValueListViewModel _pro = new PredefinedProductAttributeValueListViewModel();
                _pro.Id = item.Id;
                _pro.Name = item.Name;
                _pro.OrderNo = item.OrderNo;
                _pro.Cost = item.Cost;
                _pro.ProductAttributeId = item.ProductAttributeId;
                list.Add(_pro);
            }
            return PartialView(list);
        }

        public PartialViewResult _CreatEditProductAttributeValue(int Id)
        {
            var model = new PredefinedProductAttributeValueViewModel();
            model.ProductAttributeId = Id;
            return PartialView(model);
        }
        [HttpPost]
        public string _ValueCreatePopup(PredefinedProductAttributeValueViewModel model)
        {
            PredefinedProductAttributeValue _pro = new PredefinedProductAttributeValue();
            _pro.Cost = model.Cost;
            _pro.Name = model.Name;
            _pro.OrderNo = model.OrderNo;
            _pro.ProductAttributeId = model.ProductAttributeId;
            if (_predefinedProductAttributeValueService.Insert(_pro) != null)
                return "1";
            else
                return "-1";

        }
        [HttpPost]
        public string _ValueEditPopup(ProductAttributeValueViewModel model)
        {
            PredefinedProductAttributeValue _pro = new PredefinedProductAttributeValue();
            _pro.Id = model.Id;
            _pro.Cost = model.Cost;
            _pro.Name = model.Name;
            _pro.OrderNo = model.OrderNo;
            _pro.ProductAttributeId = model.ProductAttributeId;

            if (_predefinedProductAttributeValueService.Update(_pro))
                return "1";
            else
                return "-1";
        }

        public ActionResult GetValueByAttributeId(int Id)
        {
            if (Id == 0) throw new ArgumentException("ValueByAttribute Id degeri >>" + Id);
            var data = _predefinedProductAttributeValueService.GetById(Id);
            if (data == null) throw new ArgumentException("ValueByAttribute degeri Null");
            ProductAttributeValueViewModel model = new ProductAttributeValueViewModel();
            model.Cost = data.Cost;
            model.Name = data.Name;
            model.OrderNo = data.OrderNo;
            model.ProductAttributeId = data.ProductAttributeId;
            model.Id = data.Id;
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string _ValueDeletePop(int Id)
        {
            if (Id == 0) throw new ArgumentException("ValueByAttribute Id degeri >>" + Id);
            if (_predefinedProductAttributeValueService.Delete(Id))
                return "1";
            return "-1";
        }
    }
}