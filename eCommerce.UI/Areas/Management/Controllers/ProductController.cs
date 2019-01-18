using eCommerce.Common.SeoServices;
using eCommerce.Data.Domain.Entities;
using eCommerce.Dto.Enums;
using eCommerce.Dto.Picture;
using eCommerce.Dto.Product;
using eCommerce.Dto.ProductAttributeMapping;
using eCommerce.Dto.ProductCategoryMapping;
using eCommerce.Dto.SpecificationProductMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using eCommerce.Dto.ProductAttributeValue;
using eCommerce.Dto.ReletedProduct;
using PagedList;
using PagedList.Mvc;
namespace eCommerce.UI.Areas.Management.Controllers
{
    public class ProductController : BaseController
    {

        #region CRUD
        public ActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }
        public ActionResult List(ProductSearchViewModel model)
        {
            int PageIndex = model.Page ?? 1;
            model.CategoryList = GetCategoryDropList();
            model.BrandList = GetBrandList();


            var data = _productService.GetList(x =>

            (string.IsNullOrEmpty(model.ProductName) || x.Name.Trim().ToLower().Contains(model.ProductName)) &&
            (x.Published == model.Puhlished) &&
            (model.BrandId == 0 || x.BrandId == model.BrandId) &&
            (
              model.CategoryId == 0 || x.ProductCategoryMappings.FirstOrDefault(z => z.CategoryId==model.CategoryId).CategoryId==model.CategoryId
            )
            );
            List<ProductListViewModel> list = new List<ProductListViewModel>();
            foreach (var item in data)
            {
                ProductListViewModel _pro = new ProductListViewModel();
                _pro.BrandName = item.Brand.Name;
                _pro.ProductName = item.Name;
                _pro.Puhlished = item.Published;
                _pro.Quantity = item.Qunatity;
                _pro.Vat = item.Vat;
                _pro.Price = item.Price;
                _pro.ShowOnHomePage = item.ShowOnHomePage;
                _pro.IsFreeShipping = item.IsFreeShipping;
                _pro.Id = item.Id;
                if (item.ProductPictureMappings.FirstOrDefault(x => x.ProductId == item.Id) != null)
                {
                    _pro.Picture = item.ProductPictureMappings.FirstOrDefault(x => x.ProductId == item.Id).Picture.SmallPath;
                }
                list.Add(_pro);
            }
            model.ProductList = list.ToPagedList(PageIndex, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductList", model);
            }
            return View(model);
        }
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            model.BrandList = GetBrandList();
            model.VatList = Enums.VatList();
            model.CategoryList = GetCategoryDropList();
            model.Published = true;
            return View(model);
        }


        [HttpPost, ParameterBasedOnFormName("savecontiune", "continueEditing")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ProductViewModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                Product _pro = new Product();
                _pro.Name = model.Name;
                _pro.ShortDescription = model.ShortDescription;
                _pro.LongDescription = model.LongDescription;
                _pro.Seo = SeoService.ToSeoUrl(model.Name);
                _pro.BrandId = model.BrandId;
                _pro.OldPrice = model.OldPrice;
                _pro.Price = model.Price;
                _pro.ProductCost = model.ProductCost;
                _pro.Qunatity = model.Qunatity;
                _pro.Sku = model.Sku;
                _pro.Vat = model.Vat;
                _pro.ShowOnHomePage = model.ShowOnHomePage;
                _pro.Published = model.Published;
                _pro.IsFreeShipping = model.IsFreeShipping;
                _pro.MetaDescription = model.MetaDescription;
                _pro.MetaKeywords = model.MetaKeywords;
                _pro.MetaTitle = model.MetaTitle;
                if (_productService.Insert(_pro) != null)
                {

                    ProdutTagMappingUpdateInsert(model.ProductTags, _pro.Id);


                    if (continueEditing)
                    {
                        return RedirectToAction("Edit", "Product", new { Id = _pro.Id });
                    }
                    return RedirectToAction("List", "Product");
                }

            }

            model.VatList = Enums.VatList();
            model.BrandList = GetBrandList();
            model.CategoryList = GetCategoryDropList();
            return View(model);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return RedirectToAction("List", "Product");
            var model = new ProductViewModel();
            Product _pro = _productService.GetById(Id ?? 0);
            if (_pro != null)
            {
                model.Id = _pro.Id;
                model.Name = _pro.Name;
                model.ShortDescription = _pro.ShortDescription;
                model.LongDescription = _pro.LongDescription;
                model.Seo = _pro.Name;
                model.BrandId = _pro.BrandId;
                model.OldPrice = _pro.OldPrice;
                model.Price = _pro.Price;
                model.ProductCost = _pro.ProductCost;
                model.Qunatity = _pro.Qunatity;
                model.Sku = _pro.Sku;
                model.Vat = _pro.Vat;
                model.ShowOnHomePage = _pro.ShowOnHomePage;
                model.Published = _pro.Published;
                model.IsFreeShipping = _pro.IsFreeShipping;
                model.ProductTags = GetTags(Id ?? 0);
                model.MetaDescription = _pro.MetaDescription;
                model.MetaKeywords = _pro.MetaKeywords;
                model.MetaTitle = _pro.MetaTitle;


                model.VatList = Enums.VatList();
                model.BrandList = GetBrandList();
                model.CategoryList = GetCategoryDropList();
                return View(model);
            }
            return RedirectToAction("List", "Product");
        }


        [HttpPost, ParameterBasedOnFormName("savecontiune", "continueEditing")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ProductViewModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                Product _pro = new Product();
                _pro.Id = model.Id;
                _pro.Name = model.Name;
                _pro.ShortDescription = model.ShortDescription;
                _pro.LongDescription = model.LongDescription;
                _pro.Seo = model.Name;
                _pro.BrandId = model.BrandId;
                _pro.OldPrice = model.OldPrice;
                _pro.Price = model.Price;
                _pro.ProductCost = model.ProductCost;
                _pro.Qunatity = model.Qunatity;
                _pro.Sku = model.Sku;
                _pro.Vat = model.Vat;
                _pro.ShowOnHomePage = model.ShowOnHomePage;
                _pro.Published = model.Published;
                _pro.IsFreeShipping = model.IsFreeShipping;
                _pro.MetaDescription = model.MetaDescription;
                _pro.MetaKeywords = model.MetaKeywords;
                _pro.MetaTitle = model.MetaTitle;
                if (_productService.Update(_pro))
                {

                    ProdutTagMappingUpdateInsert(model.ProductTags, _pro.Id);


                    if (continueEditing)
                    {
                        return RedirectToAction("Edit", "Product", new { Id = _pro.Id });
                    }
                    return RedirectToAction("List", "Product");
                }

            }

            model.VatList = Enums.VatList();
            model.BrandList = GetBrandList();
            model.CategoryList = GetCategoryDropList();
            return View(model);
        }

        #endregion
        #region Picture

        [HttpPost]
        public ActionResult ProductPictureAdd(string productId, string pictureDisplayorder, string pictureTitle, string pictureAlt, string pictureId)
        {
            if (string.IsNullOrEmpty(productId) && string.IsNullOrEmpty(pictureId))
            {
                throw new Exception(string.Format("PictureId >> {0} and Produt >> {1}", pictureId, productId));
            }
            Picture _pic = _pictureService.GetById(Convert.ToInt32(pictureId));
            _pic.Alt = pictureAlt;
            _pic.Id = Convert.ToInt32(pictureId);
            _pic.Title = pictureTitle;
            _pic.OrderNo = Convert.ToInt32(pictureDisplayorder);
            if (_pictureService.Update(_pic))
            {
                ProductPictureMapping _map = new ProductPictureMapping();
                _map.PictureId = _pic.Id;
                _map.ProductId = Convert.ToInt32(productId);
                _productPictureMappingService.Insert(_map);
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductPictureList(int Id)
        {
            var model = new List<PictureListViewModel>();
            var pictures = _productPictureMappingService.GetList(x => x.ProductId == Id).ToList();
            foreach (var item in pictures)
            {
                PictureListViewModel _pic = new PictureListViewModel();
                _pic.Alt = item.Picture.Alt;
                _pic.Title = item.Picture.Title;
                _pic.OrderNo = item.Picture.OrderNo;
                _pic.Id = item.PictureId;
                _pic.SmallPath = item.Picture.SmallPath;
                _pic.Default = item.Picture.Default;

                model.Add(_pic);
            }
            return PartialView("_ProductPictureList", model);
        }

        [HttpPost]
        public ActionResult PictureDelete(int Id)
        {
            if (Id > 0)
            {
                var mappingProdut = _productPictureMappingService.Get(x => x.PictureId == Id);
                if (mappingProdut != null)
                {
                    if (_productPictureMappingService.Delete(mappingProdut))
                    {
                        var data = _pictureService.GetById(Id);
                        if (data != null)
                        {
                            if (System.IO.File.Exists(Server.MapPath((data.Default))))
                                System.IO.File.Delete(Server.MapPath("~" + data.Default));
                            if (System.IO.File.Exists(Server.MapPath((data.SmallPath))))
                                System.IO.File.Delete(Server.MapPath("~" + data.SmallPath));
                        }

                        if (_pictureService.Delete(Id))
                        {

                            return Json("1", JsonRequestBehavior.AllowGet);
                        }
                    }

                }
            }
            return Json("-1", JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region Category
        [HttpPost]
        public ActionResult ProductCategoryAdd(int categoryId, int productId)
        {
            if (categoryId > 0 && productId > 0)
            {
                ProductCategoryMapping _map = new ProductCategoryMapping();
                _map.CategoryId = categoryId;
                _map.ProductId = productId;
                if (_productCategoryMappingService.Insert(_map) != null)
                {
                    return Json(_map, JsonRequestBehavior.AllowGet);
                }
            }
            return Json("-1", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ProductCategoryDelete(int Id)
        {
            if (Id > 0)
            {
                var result = _productCategoryMappingService.Delete(Id);
                if (result)
                {
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }
        public ActionResult ProductCategoryList(int Id)
        {
            var model = new List<ProductCategoryMappingListViewModel>();
            var data = _productCategoryMappingService.GetList(x => x.ProductId == Id).ToList();
            // var cat=_categoryService.PrepareCategoryList().Where(x=>x)
            if (data != null)
            {
                foreach (var cat in data)
                {
                    foreach (var item in _categoryService.PrepareCategoryList().Where(x => x.Id == cat.CategoryId))
                    {
                        ProductCategoryMappingListViewModel _cat = new ProductCategoryMappingListViewModel();
                        _cat.CategoryId = item.Id;
                        _cat.ProductId = Id;
                        _cat.Category.Name = item.Name;
                        _cat.Category.OrderNo = item.OrderNo;
                        _cat.Category.Published = item.Published;
                        _cat.Category.CreatedById = item.CreatedById;
                        _cat.Category.CreatedDate = item.CreatedDate;
                        _cat.Category.Description = item.Description;
                        _cat.Category.ParantId = item.ParantId;
                        _cat.Category.PictureId = item.PictureId;
                        _cat.Category.UpdatedById = item.UpdatedById;
                        _cat.Category.UpdatedDate = item.UpdatedDate;
                        _cat.Id = cat.Id;
                        model.Add(_cat);
                    }

                }
            }
            return PartialView("_ProductCategoryList", model);
        }


        #endregion
        #region Specification

        public PartialViewResult ProductSpecificationAttribute()
        {
            var model = new ProductSpecificationMappingViewModel();
            model.SpecificationAttribute = GetSpecificationList();
            return PartialView("_CreateEditSpecificationAttribute", model);
        }

        public ActionResult ProductSpecificationAttributeList(int Id)
        {
            var model = new ProductSpecificationMappingListViewModel();
            List<ProductSpecificationMappingListViewModel> list = new List<ProductSpecificationMappingListViewModel>();
            if (Id > 0)
            {
                var data = _productSpecificationAttributeMappingService.GetList(x => x.ProductId == Id);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        ProductSpecificationMappingListViewModel _spec = new ProductSpecificationMappingListViewModel();
                        _spec.AttributeTypeId = item.AttributeTypeId;
                        _spec.CustomValue = item.CustomValue;
                        _spec.Id = item.Id;
                        _spec.ShowOnProductPage = item.ShowOnProductPage;
                        if (!string.IsNullOrEmpty(item.CustomValue))
                        {
                            _spec.SpecificationAttributeValue = item.CustomValue;
                        }
                        else
                        {
                            _spec.SpecificationAttributeValue = item.SpecificationAttributeValue.Name;

                        }
                        _spec.SpecificationAttribute = item.SpecificationAttributeValue.SpecificationAttribute.Name;
                        list.Add(_spec);
                    }
                }

            }
            return PartialView("_ProductSpecificationAttributeList", list);
        }


        [HttpPost]
        public ActionResult ProductSpecificationValueAdd(string productId, string AttributeTypeId, string SpecificationAttributeValueId, string CustomValue, string ShowOnProductPage)
        {
            if (string.IsNullOrEmpty(productId) && string.IsNullOrEmpty(AttributeTypeId))
            {
                throw new Exception("Product Specification Null");
            }
            ProductSpecificationAttributeMapping _map = new ProductSpecificationAttributeMapping();
            //SpecificationAttributeType att =(SpecificationAttributeType) Enum.Parse(typeof(SpecificationAttributeType), AttributeType);
            //var AttributeId= Convert.ToInt32((SpecificationAttributeType)att).ToString();

            _map.AttributeTypeId = Convert.ToInt32(AttributeTypeId);
            _map.CustomValue = CustomValue;
            _map.ProductId = Convert.ToInt32(productId);
            _map.ShowOnProductPage = Convert.ToBoolean(ShowOnProductPage);
            _map.SpecificationAttributeValueId = Convert.ToInt32(SpecificationAttributeValueId);
            if (_productSpecificationAttributeMappingService.Insert(_map) != null)
                return Json("1", JsonRequestBehavior.AllowGet);
            else
                return Json("-1", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult ProductSpecificationValueDelete(int Id)
        {
            if (Id == 0)
            {
                throw new Exception("Product Specification Null");
            }
            var result = _productSpecificationAttributeMappingService.Delete(Id);
            if (result)
            {
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            return Json("-1", JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region ProductAttribute

        public ActionResult ProductAttributeList(int Id)
        {
            var model = new List<ProductAttributeMappingListViewModel>();
            if (Id > 0)
            {

                var data = _productAttributeMappingService.GetList(x => x.ProductId == Id).ToList();
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        ProductAttributeMappingListViewModel _mod = new ProductAttributeMappingListViewModel();
                        _mod.Id = item.Id;
                        _mod.ProductAttributeId = item.ProductAttributeId;
                        _mod.ProductId = item.ProductId;
                        _mod.TextPrompt = item.TextPrompt;
                        _mod.ProductAttribute = item.ProductAttribute.Name;
                        _mod.AttributeControlTypeId = item.AttributeControlTypeId;
                        model.Add(_mod);
                    }
                }
            }
            return PartialView("_ProductAttributeList", model);
        }

        public ActionResult ProductAttribute()
        {
            var model = new ProductAttributeMappingViewModel();
            model.ProductAttribute = GetProductAttribute();
            return PartialView("_CreateEditProductAttributeValue", model);
        }
        [HttpPost]
        public ActionResult ProductAttributeAdd(string productId, string attributecontroltype, string productattributeId, string textprompt)
        {
            if (string.IsNullOrEmpty(productId))
            {
                throw new Exception("product Id" + productId);
            }
            if (string.IsNullOrEmpty(productattributeId))
            {
                throw new Exception("productattribute Id" + productattributeId);
            }

            ProductAttributeMapping _map = new ProductAttributeMapping();
            _map.AttributeControlTypeId = Convert.ToInt32(attributecontroltype);
            _map.ProductAttributeId = Convert.ToInt32(productattributeId);
            _map.ProductId = Convert.ToInt32(productId);
            _map.TextPrompt = textprompt;
            if (_productAttributeMappingService.Insert(_map) != null)
            {
                int _productAttributeId = Convert.ToInt32(productattributeId);
                var data = _predefinedProductAttributeValueService.GetList(x => x.ProductAttributeId == _productAttributeId).ToList();
                if (data != null)
                {
                    var result = false;
                    ProductAttributeValue _value = null;
                    foreach (var item in data)
                    {
                        _value = new ProductAttributeValue();
                        _value.AttributeValueTypeId = 0;
                        _value.Cost = item.Cost;
                        _value.Name = item.Name;
                        _value.OrderNo = item.OrderNo;
                        _value.Quantity = 0;
                        _value.ProductAttributeMappingId = _map.Id;
                        result = _prodcutAttributeValueService.Insert(_value) != null ? true : false;
                    }
                    if (result)
                    {
                        return Json("1", JsonRequestBehavior.AllowGet);
                    }
                }
            }

            return Json("-1", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ProductAttributeDelete(int Id)
        {
            if (Id > 0)
            {
                var value = _prodcutAttributeValueService.GetList(x => x.ProductAttributeMappingId == Id).ToList();
                if (value.Count > 0)
                {
                    if (_prodcutAttributeValueService.Delete(value))
                    {
                        if (_productAttributeMappingService.Delete(Id))
                            return Json("1", JsonRequestBehavior.AllowGet);
                        else
                            return Json("-1", JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    if (_productAttributeMappingService.Delete(Id))
                        return Json("1", JsonRequestBehavior.AllowGet);
                    else
                        return Json("-1", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("");
        }

        public ActionResult ProductAttributeValue(int? Id)
        {

            var model = new List<ProductAttributeValueListViewModel>();

            var data = _prodcutAttributeValueService.GetList(x => x.ProductAttributeMappingId == Id).ToList();
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    ProductAttributeValueListViewModel _value = new ProductAttributeValueListViewModel();
                    _value.Cost = item.Cost;
                    _value.Id = item.Id;
                    _value.Name = item.Name;
                    _value.OrderNo = item.OrderNo;
                    _value.ProductAttributeId = item.ProductAttributeMappingId;
                    _value.Quantity = item.Quantity;

                    model.Add(_value);

                }
            }

            return PartialView("_ProductAttributeValue", model);
        }

        [HttpPost]
        public ActionResult ProductAttributeValueDelete(int Id)
        {
            if (Id > 0)
            {
                if (_prodcutAttributeValueService.Delete(Id))
                {
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json("-1", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("");
        }
        [HttpPost]
        public ActionResult ProductAttributeValueEdit(string Id, string orderNo, string quantiy, string cost)
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("Id" + Id);
            }

            int valueId = Convert.ToInt32(Id);
            ProductAttributeValue _value = _prodcutAttributeValueService.GetById(valueId);
            _value.AttributeValueTypeId = 0;
            _value.Cost = Convert.ToDecimal(cost);
            _value.OrderNo = Convert.ToInt32(orderNo);
            _value.Quantity = Convert.ToInt32(quantiy);
            if (_prodcutAttributeValueService.Update(_value))
                return Json("1", JsonRequestBehavior.AllowGet);
            else

                return Json("-1", JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region RelatedProduct
        public ActionResult RelatedProductPopup(RelatedProductSearchViewModel model)
        {
            int pageIndex = model.Page ?? 1;

            model.RelatedProductList = _productService.GetList(y =>
                   (string.IsNullOrEmpty(model.ProductName) || y.Name.ToLower().Contains(model.ProductName.ToLower()))
                  ).Select(x => new RelatedProductListViewModel
                  {
                      ProductId = x.Id,
                      ProductName = x.Name,
                      Published = x.Published,
                      BrandName = x.Brand.Name

                  }).ToPagedList(pageIndex, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_RelatedProductList", model);
            }
            return PartialView("RelatedProductPopup", model);
        }

        public ActionResult ProductRelatedList(int Id, int? Page)
        {
            int pageIndex = Page ?? 1;
            var model = new RelatedProductSearchViewModel();
            var data = _relatedProductService.GetList(x => x.ProductId1 == Id).ToList();

            List<RelatedProductListViewModel> list = new List<RelatedProductListViewModel>();
            foreach (var item in data)
            {
                foreach (var _pro in _productService.GetList(x => x.Id == item.ProductId2))
                {
                    RelatedProductListViewModel _related = new RelatedProductListViewModel();
                    _related.Id = item.Id;
                    _related.ProductName = _pro.Name;
                    _related.BrandName = _pro.Brand.Name;
                    _related.Published = _pro.Published;
                    list.Add(_related);
                }

            }
            model.RelatedProductList = list.ToPagedList(pageIndex, 10);


            return PartialView("_ProductRelatedList", model);
        }
        [HttpPost]
        public ActionResult RelatedProductAdd(int Id, int productId)
        {
            RelatedProduct _related = new RelatedProduct();
            _related.ProductId1 = productId;
            _related.ProductId2 = Id;
            _related.OrderNo = 0;
            if (_relatedProductService.Insert(_related) != null)
                return Json("1", JsonRequestBehavior.AllowGet);
            else
                return Json("-1", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult RelatedProductDelete(int Id)
        {
            if (_relatedProductService.Delete(Id))
                return Json("1", JsonRequestBehavior.AllowGet);
            else
                return Json("-1", JsonRequestBehavior.AllowGet);
        } 
        #endregion
        #region Method
        private List<SelectListItem> GetBrandList()
        {
            var data = _brandService.GetList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return data.ToList();
        }
        private void ProdutTagMappingUpdateInsert(string tags, int Id)
        {
            if (!string.IsNullOrEmpty(tags) && Id > 0)
            {
                var tagmappings = _productTagMappingService.GetList(x => x.ProductId == Id).ToList();
                if (tagmappings != null)
                {
                    _productTagMappingService.Delete(tagmappings);
                }

                string[] value = tags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in value)
                {
                    ProductTag _tag = _produtTagService.Get(x => x.Name.Trim().ToLower().Contains(item.Trim().ToLower()));
                    if (_tag == null)
                    {
                        _tag = new ProductTag();
                        _tag.Name = item.Trim().ToLower();
                        _produtTagService.Insert(_tag);
                    }
                    ProductTagMapping tagmapping = new ProductTagMapping();
                    tagmapping.ProductId = Id;
                    tagmapping.ProductTagId = _tag.Id;
                    _productTagMappingService.Insert(tagmapping);


                }

            }

        }

        private string GetTags(int Id)
        {
            var result = new StringBuilder();
            var data = _productTagMappingService.GetList(x => x.ProductId == Id);
            if (data != null)
            {
                foreach (var tag in data)
                {
                    if (tag.ProductTag != null)
                    {
                        result.Append(tag.ProductTag.Name);
                        result.Append(",");
                    }

                }

            }

            return result.ToString();
        }
        private List<SelectListItem> GetCategoryDropList()
        {
            var data = _categoryService.PrepareCategoryList().OrderBy(x => x.Id).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return data.OrderBy(x => x.Text).ToList();
        }
        private List<SelectListItem> GetProductAttribute()
        {

            return _productAttributeService.GetList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).OrderBy(x => x.Text).ToList();
        }
        private List<SelectListItem> GetSpecificationList()
        {
            return _specificationAttributeService.GetList().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Value).ToList();
        }

        [HttpPost]
        public ActionResult ProductSpecificationValue(int Id)
        {
            var data = _specificationAttributeValueService.GetList(x => x.SpecificationAttributeId == Id);

            List<SelectListItem> model = (from i in data select new SelectListItem { Text = i.Name, Value = i.Id.ToString() }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}