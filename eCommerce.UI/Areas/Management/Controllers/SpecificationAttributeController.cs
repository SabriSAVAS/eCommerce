using eCommerce.Data.Domain.Entities;
using eCommerce.Dto.Specification;
using eCommerce.Dto.SpecificationValue;
using eCommerce.Service.Specifications;
using eCommerce.Service.SpecificationValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Areas.Management.Controllers
{
    public class SpecificationAttributeController : BaseController
    {
        // GET: Management/SpecificationAttribute
        private SpecificationAttributeService _specificationService;
        private SpecificationAttributeValueService _specificationValueService;
        public SpecificationAttributeController()
        {
            _specificationValueService = new SpecificationAttributeValueService();
            _specificationService = new SpecificationAttributeService();
        }
        public ActionResult Index()
        {
            return RedirectToAction("List", "SpecificationAttribute");
        }

        public ActionResult List()
        {
            var data = _specificationService.GetList();
            List<SpecificationAttributeListViewModel> list = new List<SpecificationAttributeListViewModel>();
            foreach (var item in data)
            {
                SpecificationAttributeListViewModel model = new SpecificationAttributeListViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.OrderNo = item.OrderNo;
                list.Add(model);
            }
            return View(list);
        }
        public ActionResult Create()
        {
            var model = new SpecificationAttributeViewModel();
            return View(model);
        }
        [HttpPost, ParameterBasedOnFormName("savecontiune", "contiuneEditing")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpecificationAttributeViewModel model, bool contiuneEditing)
        {
            if (ModelState.IsValid)
            {
                SpecificationAttribute _spec = new SpecificationAttribute();
                _spec.Name = model.Name;
                _spec.OrderNo = model.OrderNo;
                if (_specificationService.Insert(_spec) != null)
                    Success("Kayit işlemi başarılı bir şekilde gerçekleşti.");
                else
                    Danger("Kayit işlemi sırasında bir hata gerçekleşti");

                if (contiuneEditing)
                {
                    return RedirectToAction("Edit", "SpecificationAttribute", new { Id = _spec.Id });
                }
                return RedirectToAction("List", "SpecificationAttribute");

            }
            return View(model);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return RedirectToAction("List", "SpecificationAttribute");
            SpecificationAttributeViewModel model = new SpecificationAttributeViewModel();
            var _spec = _specificationService.GetById(Id ?? 0);
            if (_spec != null)
            {
                model.Id = _spec.Id;
                model.Name = _spec.Name;
                model.OrderNo = _spec.OrderNo;
            }

            return View(model);
        }
        [HttpPost, ParameterBasedOnFormName("savecontiune", "contiuneEditing")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SpecificationAttributeViewModel model, bool contiuneEditing)
        {
            if (ModelState.IsValid)
            {
                SpecificationAttribute _spec = new SpecificationAttribute();
                _spec.Id = model.Id;
                _spec.Name = model.Name;
                _spec.OrderNo = model.OrderNo;
                if (_specificationService.Update(_spec))
                    Success("Kayit işlemi başarılı bir şekilde gerçekleşti.");
                else
                    Danger("Kayit işlemi sırasında bir hata gerçekleşti");

                if (contiuneEditing)
                {
                    return RedirectToAction("Edit", "SpecificationAttribute", new { Id = _spec.Id });
                }
                return RedirectToAction("List", "SpecificationAttribute");

            }
            return View(model);
        }


        public PartialViewResult _ValueAttributeList(int Id)
        {
            var data = _specificationValueService.GetList(x => x.SpecificationAttributeId == Id);
            List<SpecificationAttributeValueListViewModel> list = new List<SpecificationAttributeValueListViewModel>();
            foreach (var item in data)
            {
                SpecificationAttributeValueListViewModel model = new SpecificationAttributeValueListViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.SpecificationAttributeId = item.SpecificationAttributeId;
                model.OrderNo = item.OrderNo;
                list.Add(model);
            }
            return PartialView(list);
        }

        public PartialViewResult _ValueCreatePopup(int Id)
        {
            var model = new SpecificationAttributeValueViewModel();

            model.SpecificationAttributeId = Id;

            return PartialView(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string _ValueCreatePopup(SpecificationAttributeValueViewModel model)
        {
            if (ModelState.IsValid)
            {
                SpecificationAttributeValue _spec = new SpecificationAttributeValue();
                _spec.Name = model.Name;
                _spec.OrderNo = model.OrderNo;
                _spec.SpecificationAttributeId = model.SpecificationAttributeId;
                if (model.ValueId > 0)
                {
                    _spec.Id = model.ValueId;
                    if (_specificationValueService.Update(_spec))
                        return "1";
                    else
                        return "-1";
                }
                else
                {
                    if (_specificationValueService.Insert(_spec) != null)
                        return "1";
                    else
                        return "-1";
                }

            }
            return "-1";
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public string _ValueEditePopup(SpecificationAttributeValueViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        SpecificationAttributeValue _spec = new SpecificationAttributeValue();
        //        _spec.Id = model.ValueId;
        //        _spec.Name = model.Name;
        //        _spec.OrderNo = model.OrderNo;
        //        _spec.SpecificationAttributeId = model.SpecificationAttributeId;
        //        if (_specificationValueService.Update(_spec))
        //        {
        //            return "1";
        //        }

        //        else
        //        {

        //            return "-1";
        //        }
        //    }
        //    return "-1";
        //}
        public ActionResult GetValueByAttributeId(int Id)
        {
            var data = _specificationValueService.GetById(Id);
            var model = new SpecificationAttributeValueViewModel();
            if (data != null)
            {
                model.ValueId = data.Id;
                model.Name = data.Name;
                model.OrderNo = data.OrderNo;
                model.SpecificationAttributeId = data.SpecificationAttributeId;
            }
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public string ValueAttribureDelete(int Id)
        {
            if (Id == 0) return "-1";
            var data = _specificationValueService.Delete(Id);
            if (data)
            { Success("Silme işlemi başarılı bir şelide gerçekleşti"); return "1"; }
            else
            {
                Danger("Silme işlemi sırasında bir hata ile karşılaşıldı.");

                return "1";
            }
        }

    }
}