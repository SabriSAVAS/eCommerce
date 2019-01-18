using eCommerce.Common.ImgService;
using eCommerce.Common.SeoServices;
using eCommerce.Data.Domain.Entities;
using eCommerce.Dto.Brand;
using eCommerce.Service.Brands;
using eCommerce.Service.Pictutes;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace eCommerce.UI.Areas.Management.Controllers
{
    public class BrandController : BaseController
    {
        // GET: Management/Brand
        private BrandService _brandservice = null;
        private PictureService _pictureservice = null;
        public BrandController()
        {
            _brandservice = new BrandService();
            _pictureservice = new PictureService();
        }
        public ActionResult Index()
        {
            return RedirectToAction("List", "Brand");
        }
        public ActionResult List(BrandSearchViewModel model)
        {   
            int pageIndex = model.Page ?? 1;
            var data = _brandservice.GetList(x => (string.IsNullOrEmpty(model.BrandName) ||
            x.Name.ToLower().Contains(model.BrandName.ToLower())));
            List<BrandListViewModel> list = new List<BrandListViewModel>();
            foreach (var item in data)
            {
                BrandListViewModel _brand = new BrandListViewModel();
                _brand.BrandName = item.Name;
                _brand.Id = item.Id;
                _brand.OrderNo = item.OrderNo;
                list.Add(_brand);
            }

            model.BrandList = list.ToPagedList(pageIndex, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_BrandList", model);
            }
            return View(model);
        }
        public ActionResult Create()
        {
            var model = new BrandViewModel();
            return View(model);
        }
        [HttpPost, ParameterBasedOnFormName("savecontiune", "continueEditing")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BrandViewModel model, bool continueEditing)
        {
            
            Brand _brand = new Brand();
            Picture _pic = new Picture();
            if (ModelState.IsValid)
            {
                InsertPicture(_pic, model);

                //var data = QMapper.CloneClassicVersion(model, typeof(Brand)) as Brand;

                _brand.Name = model.Name;
                _brand.Description = model.Description;
                _brand.OrderNo = model.OrderNo;
                _brand.Seo = SeoService.ToSeoUrl(model.Name);
                _brand.CreatedById = 1;
                _brand.CreatedDate = DateTime.Now;
                _brand.IsActive = true;
                _brand.IsDeleted = false;
                if (_pic.Id > 0)
                {
                    _brand.PictureId = _pic.Id;
                }
                if (_brandservice.Insert(_brand) != null)
                    Success("Kayit işlemi başarılı bir şekilde gerçekleşti");
                else
                    Danger("Kayit işlemi sırasında problem oluştu");


                if (continueEditing)
                {
                    return RedirectToAction("Edit", "Brand", new { id = _brand.Id });

                }
                else
                {
                    return RedirectToAction("List", "Brand");
                }

            }
            return View(model);

        }

        private void InsertPicture(Picture _pic, BrandViewModel model)
        {
            if (model.Picture != null && model.Picture.ContentLength > 0 && model.PictureId == 0 || model.PictureId == null)
            {
                _pic.Title = model.Name;
                _pic.SmallPath = ImgUploadService.imgSingUpload(model.Picture, 200, 200);
                _pic.Default = ImgUploadService.imgDefaultSingUpload(model.Picture);
                _pic.Alt = model.Name;
                _pic.OrderNo = 0;
                _pictureservice.Insert(_pic);
            }
            if (model.Picture != null && model.Picture.ContentLength > 0 && model.PictureId > 0 && model.PictureId != null)
            {

                _pic.Id = model.PictureId ?? 0;
                _pic.Title = model.Name;
                _pic.SmallPath = ImgUploadService.imgSingUpload(model.Picture, 200, 200);
                _pic.Default = ImgUploadService.imgDefaultSingUpload(model.Picture);
                _pic.Alt = model.Name;
                _pic.OrderNo = 0;
                _pictureservice.Update(_pic);
            }
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return RedirectToAction("List", "Brand");
            var data = _brandservice.GetById(Id ?? 0);
            var model = new BrandViewModel();
            if (data != null)
            {
                model.Id = data.Id;
                model.Name = data.Name;
                model.Description = data.Description;
                model.CreatedById = data.CreatedById;
                model.CreatedDate = data.CreatedDate;
                model.OrderNo = data.OrderNo;
                model.Seo = data.Seo;
                model.UpdatedById = data.UpdatedById;
                model.UpdatedDate = data.UpdatedDate;
                model.PictureId = data.PictureId;
                if (data.Picture != null)
                {
                    model.PicturePath = data.Picture.SmallPath;
                }

            }
            return View(model);
        }
        [HttpPost, ParameterBasedOnFormName("savecontiune", "continueEditing")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BrandViewModel model, bool continueEditing)
        {
            Brand _brand = new Brand();
            Picture _pic = new Picture();
            if (ModelState.IsValid)
            {
                InsertPicture(_pic, model);

                _brand.Id = model.Id;
                _brand.Name = model.Name;
                _brand.Description = model.Description;
                _brand.OrderNo = model.OrderNo;
                _brand.Seo = SeoService.ToSeoUrl(model.Name);
                _brand.CreatedById = model.CreatedById;
                _brand.CreatedDate = model.CreatedDate;
                _brand.UpdatedById = 1;
                _brand.UpdatedDate = DateTime.Now;
                _brand.IsActive = true;
                _brand.IsDeleted = false;
                if (_pic.Id > 0)
                {
                    _brand.PictureId = _pic.Id;
                }
                else
                {
                    _brand.PictureId = model.PictureId;
                }
                if (_brandservice.Update(_brand))
                    Success("Güncelleme işlemi başarılı bir şekilde gerçekleşti");
                else
                    Danger("Guncelleme işlemi sırasında bir hata oluştu");
                if (continueEditing)
                {
                    return RedirectToAction("Edit", "Brand", new { id = _brand.Id });

                }
              
                    return RedirectToAction("List", "Brand");
               
            }
            return View(model);

        }

        [HttpPost]
        public string Delete(int Id)
        {
            if (Id > 0)
            {
                var data = _brandservice.GetById(Id);
                if (data != null)
                {
                    if(data.Picture!=null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(data.Picture.SmallPath)))
                            System.IO.File.Delete(Server.MapPath("~" + data.Picture.SmallPath));
                        if (System.IO.File.Exists(Server.MapPath(data.Picture.Default)))
                            System.IO.File.Delete(Server.MapPath("~" + data.Picture.Default));

                    }


                    _brandservice.Delete(Id);
                    _pictureservice.Delete(data.PictureId ?? 0);

                    Success("Silme işlemi başarılı bir şekilde gerçekleşti");
                    return "1";
                }
                else
                {
                    Danger("Silme işlemi sırasında bir hata gerçekleşti");
                    return "-1";
                }
            }
            Danger("Silme işlemi sırasında bir hata gerçekleşti");
            return "-1";
        }
    }
}