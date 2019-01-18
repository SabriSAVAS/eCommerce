using eCommerce.Data.Domain.Entities;
using eCommerce.Dto.Category;
using eCommerce.Service.Categories;
using eCommerce.Service.Pictutes;
using eCommerce.Common.ImgService;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System;
using PagedList;
using eCommerce.Dto.Product;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using eCommerce.Common.SeoServices;
using eCommerce.Service.Exports;

namespace eCommerce.UI.Areas.Management.Controllers
{

    public class CategoryController : BaseController
    {
        public int PictureId { get; set; }
      
        #region CreteAndDelete
        public ActionResult Index()
        {
            return RedirectToAction("List", "Category");
        }

        public ActionResult List(CategorySearchViewModel model)
        {
            int pageIndex = model.Page ?? 1;
          

            var data = _categoryService.PrepareCategoryList().OrderBy(x => x.Name).Where(x =>
              (string.IsNullOrEmpty(model.CategoryName) || x.Name.ToLower().Contains(model.CategoryName.ToLower()))).ToList();

            List<CategoryListViewModel> list = new List<CategoryListViewModel>();
            foreach (var item in data)
            {
                CategoryListViewModel _cat = new CategoryListViewModel();
                _cat.Name = item.Name;
                _cat.Id = item.Id;
                _cat.OrderNo = item.OrderNo;
                _cat.Published = item.Published;
                list.Add(_cat);
            }

            model.CategoryList = list.ToPagedList(pageIndex, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CategoryList", model);
            }
            return View(model);
        }
        public ActionResult Create()
        {
            var Model = new CategoryViewModel();
            Model.CategoryList = GetCategoryDropList();
            Model.Published = true;

            return View(Model);
        }
        [HttpPost, ParameterBasedOnFormName("savecontiune", "continueEditing")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model, bool continueEditing)
        {
            Category cat = new Category();

            if (ModelState.IsValid)
            {
                Picture pic = new Picture();

                InsertPicture(pic, model);

                cat.Id = model.Id;
                cat.Name = model.Name;
                cat.Seo = SeoService.ToSeoUrl(model.Name);
                cat.Description = model.Description;
                cat.ParantId = model.ParantId ?? 0;
                cat.Published = model.Published;
                cat.OrderNo = model.OrderNo;
                if (pic.Id > 0)
                {
                    cat.PictureId = pic.Id;
                }
                cat.CreatedById = 1;
                cat.CreatedDate = DateTime.Now;
                cat.IsActive = true;
                cat.IsDeleted = false;

                if (_categoryService.Insert(cat) != null)
                    Success("İşlem Başarılı");
                else
                    Danger("İşlem Başarısız");

                if (continueEditing)
                {
                    return RedirectToAction("Edit", "Category", new { id = cat.Id });
                }
                else
                {
                    return RedirectToAction("List", "Category");
                }

            }
            model.CategoryList = GetCategoryDropList();
            return View(model);

        }
        public ActionResult Edit(int? Id)
        {
            if (Id == null) return RedirectToAction("List", "Category");
            var model = new CategoryViewModel();
            var data = _categoryService.GetById(Id ?? 0);
            if (data != null)
            {
                model.CategoryList = GetCategoryDropList();
                model.Name = data.Name;
                model.Description = data.Description;
                model.Id = data.Id;
                model.OrderNo = data.OrderNo;
                model.ParantId = data.ParantId;
                model.Published = data.Published;
                model.CreatedDate = data.CreatedDate;
                model.CreatedById = data.CreatedById;
                model.PictureId = data.PictureId;
                if (data.Picture != null)
                {
                    model.PicturePath = data.Picture.SmallPath;
                }

                return View(model);
            }
            return RedirectToAction("List", "Category");
        }
        public PartialViewResult _CategoryProductList(int? Id, int? page)
        {
            var data = _categoryService.GetById(Id ?? 0);
            if (data == null) return null;
            int pageIndex = page ?? 1;

            List<ProductListViewModel> list = new List<ProductListViewModel>();

            foreach (var item in data.ProductCategoryMappings)
            {
                ProductListViewModel _pro = new ProductListViewModel();
                _pro.ProductName = item.Product.Name;
                _pro.Puhlished = item.Product.Published;
                _pro.Id = item.Product.Id;
                list.Add(_pro);
            }
            var model = list.ToPagedList(pageIndex, 2);
            return PartialView(model);
        }
        [HttpPost, ParameterBasedOnFormName("savecontiune", "continueEditing")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                Picture pic = new Picture();

                InsertPicture(pic, model);

                Category cat = new Category();
                cat.Id = model.Id;
                cat.Name = model.Name;
                cat.Seo = SeoService.ToSeoUrl(model.Name);
                cat.Description = model.Description;
                cat.ParantId = model.ParantId ?? 0;
                if (pic.Id > 0)
                {
                    cat.PictureId = pic.Id;
                }
                else
                {
                    cat.PictureId = model.PictureId;
                }
                cat.Published = model.Published;
                cat.OrderNo = model.OrderNo;
                cat.UpdatedDate = DateTime.Now;
                cat.UpdatedById = 1;
                cat.CreatedById = model.CreatedById;
                cat.CreatedDate = model.CreatedDate;
                cat.IsActive = true;
                cat.IsDeleted = false;
                if (pic.Id > 0)
                {
                    cat.PictureId = pic.Id;
                }
                if (_categoryService.Update(cat) == true)
                {
                    Success("Güncelleme işlemi Başarılı");
                }
                else
                {
                    Danger("Güncelleme işlemi Başarısız");
                }
                if (continueEditing)
                {
                    return RedirectToAction("Edit", "Category", new { id = model.Id });

                }
                else
                {
                    return RedirectToAction("List", "Category");
                }
            }
            model.CategoryList = GetCategoryDropList();

            return View(model);


        }

        private void InsertPicture(Picture _pic, CategoryViewModel model)
        {
            if (model.Picture != null && model.Picture.ContentLength > 0 && model.PictureId == 0 || model.PictureId == null)
            {

                _pic.Title = model.Name;
                _pic.SmallPath = ImgUploadService.imgSingUpload(model.Picture, 200, 200);
                _pic.Default = ImgUploadService.imgDefaultSingUpload(model.Picture);
                _pic.Alt = model.Name;
                _pic.OrderNo = 0;
                _pictureService.Insert(_pic);
            }
            if (model.Picture != null && model.Picture.ContentLength > 0 && model.PictureId > 0 && model.PictureId != null)
            {
                _pic.Id = model.PictureId ?? 0;
                _pic.Title = model.Name;
                _pic.SmallPath = ImgUploadService.imgSingUpload(model.Picture, 200, 200);
                _pic.Default = ImgUploadService.imgDefaultSingUpload(model.Picture);
                _pic.Alt = model.Name;
                _pic.OrderNo = 0;
                _pictureService.Update(_pic);
            }
        }

        [HttpPost]
        public string Delete(int Id)
        {

            if (Id > 0)
            {
                var data = _categoryService.GetById(Id);
                if (data != null)
                {
                    PictureId = data.PictureId ?? 0;
                    if (data.Picture != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~" + data.Picture.SmallPath)))
                            System.IO.File.Delete(Server.MapPath("~" + data.Picture.SmallPath));
                        if (System.IO.File.Exists(Server.MapPath("~" + data.Picture.Default)))
                            System.IO.File.Delete(Server.MapPath("~" + data.Picture.Default));
                    }
                    if (_categoryService.Delete(data) == true)
                    {
                        _pictureService.Delete(PictureId);
                        Success("Silme işlemi başarılı bir şekilde yapildi.");
                        return "1";
                    }
                    else
                    {
                        Danger("Silme işlemi sırasında bir hata gerçekleşti.");
                        return "2";
                    }
                }
                else
                {
                    Information("Silme işlemi sırasında bir hata gerçekleşti.");
                    return "2";
                }
            }
            return "-1";
        }

        #endregion

        #region Method
        private List<SelectListItem> GetCategoryDropList()
        {
            var data = _categoryService.PrepareCategoryList().OrderBy(x => x.Id).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return data;
        }
        #endregion

        public FileResult ExportXlsx()
        {
            ExportXlsxService _export = new ExportXlsxService();
            var dt = _export.CategoryExport();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CategoryExport.xlsx");
                }
            }
           
        }

    }
}