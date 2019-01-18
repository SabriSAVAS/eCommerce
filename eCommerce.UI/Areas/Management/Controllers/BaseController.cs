using eCommerce.Service.Brands;
using eCommerce.Service.Categories;
using eCommerce.Service.CustomerRoles;
using eCommerce.Service.CustomerRolMappings;
using eCommerce.Service.Customers;
using eCommerce.Service.Pictutes;
using eCommerce.Service.PredefinedProductAttributeValues;
using eCommerce.Service.ProductAttributeMappings;
using eCommerce.Service.ProductAttributes;
using eCommerce.Service.ProductAttributeValues;
using eCommerce.Service.ProductCategoryMappings;
using eCommerce.Service.ProductPictureMappings;
using eCommerce.Service.Products;
using eCommerce.Service.ProductSpecificationAttributeMappings;
using eCommerce.Service.ProductTagMappings;
using eCommerce.Service.ProductTags;
using eCommerce.Service.RelatedProducts;
using eCommerce.Service.Specifications;
using eCommerce.Service.SpecificationValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.UI.Areas.Management.Controllers
{
    public class BaseController : Controller
    {
        public RelatedProductService _relatedProductService = null;
        public ProductService _productService = null;
        public ProductSpecificationAttributeMappingService _productSpecificationAttributeMappingService = null;
        public ProductTagMappingService _productTagMappingService = null;
        public ProductPictureMappingService _productPictureMappingService = null;
        public ProductCategoryMappingService _productCategoryMappingService = null;
        public ProductAttributeMappingService _productAttributeMappingService = null;
        public ProdcutAttributeValueService _prodcutAttributeValueService = null;
        public ProductTagService _produtTagService = null;
        public ProductAttributeService _productAttributeService = null;
        public SpecificationAttributeService _specificationAttributeService = null;
        public SpecificationAttributeValueService _specificationAttributeValueService = null;
        public PredefinedProductAttributeValueService _predefinedProductAttributeValueService = null;
        public PictureService _pictureService = null;
        
        public CategoryService _categoryService = null;
        public BrandService _brandService = null;

        public CustomerService _customerService = null;
        public CustomerRoleService _customerRoleService = null;
        public CustomerRolMappingService _customerRoleMappingService = null;
        public BaseController()
        {
            _relatedProductService = new RelatedProductService();
            _productSpecificationAttributeMappingService = new ProductSpecificationAttributeMappingService();
            _specificationAttributeValueService = new SpecificationAttributeValueService();
            _specificationAttributeService = new SpecificationAttributeService();
            _prodcutAttributeValueService = new ProdcutAttributeValueService();
            _productAttributeService = new ProductAttributeService();
            _productCategoryMappingService = new ProductCategoryMappingService();
            _categoryService = new CategoryService();
            _productPictureMappingService = new ProductPictureMappingService();
            _pictureService = new PictureService();
            _productService = new ProductService();
            _brandService = new BrandService();
            _productTagMappingService = new ProductTagMappingService();
            _produtTagService = new ProductTagService();
            _predefinedProductAttributeValueService = new PredefinedProductAttributeValueService();
            _productAttributeMappingService = new ProductAttributeMappingService();

            _customerService = new CustomerService();
            _customerRoleService = new CustomerRoleService();
            _customerRoleMappingService = new CustomerRolMappingService();
        }
        protected override void Dispose(bool disposing)
        {
            _relatedProductService.Dispose();
            _productSpecificationAttributeMappingService.Dispose();
            _specificationAttributeValueService.Dispose();
            _specificationAttributeService.Dispose();
            _prodcutAttributeValueService.Dispose();
            _productAttributeService.Dispose();
            _productCategoryMappingService.Dispose();
            _categoryService.Dispose();
            _productPictureMappingService.Dispose();
            _pictureService.Dispose();
            _productService.Dispose();
            _brandService.Dispose();
            _productTagMappingService.Dispose();
            _produtTagService.Dispose();
            _predefinedProductAttributeValueService.Dispose();
            _productAttributeMappingService.Dispose();
            _customerService.Dispose();
            _customerRoleService.Dispose();
            _customerRoleMappingService.Dispose();
        }
        public void Success(string message)
        {
            AddAlert(AlertStyles.Success, message);
        }

        public void Information(string message)
        {
            AddAlert(AlertStyles.Information, message);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message);
        }

        public void Danger(string message)
        {
            AddAlert(AlertStyles.Danger, message);
        }

        private void AddAlert(string alertStyle, string message)
        {
            TempData["Alert"] = alertStyle;
            TempData["Message"] = message;
        }
        public static class AlertStyles
        {
            public const string Success = "success";
            public const string Information = "info";
            public const string Warning = "warning";
            public const string Danger = "danger";
        }
        public void GetRedirectValue(string action,string controller,int Id)
        {
            if (HttpContext.Request.Form.GetValues("savecontiune") != null && Id != 0)
            {
               RedirectToAction(action,controller, new { id = Id });

            }
            else
            {
                RedirectToAction(action, controller);
            }
        }

      
    }
}