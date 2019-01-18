using eCommerce.Dto.Attributes;
using eCommerce.DTO.Attributes;
using eCommerce.Dto.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Linq.Expressions;

namespace eCommerce.Dto.Category
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            SubCategory = new List<CategoryViewModel>();
            CategoryList = new List<SelectListItem>();

        }
        [Required(ErrorMessage = "Lütfen bir isim girin.")]
        public string Name { get; set; }
        public string Seo { get; set; }
        public string Description { get; set; }
        //[FileSizeAttributes(10)]
        [FileExtentionAttributes(".jpg;.png")]
        public HttpPostedFileBase Picture { get; set; }
        public string PicturePath { get; set; }
        public int? PictureId { get; set; }
        public int? ParantId { get; set; }
        public bool Published { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedById
        {
            get; set;
        }

        public DateTime CreatedDate
        {
            get; set;
        }
        public List<CategoryViewModel> SubCategory { get; set; }
        public int Id { get; set; }

        //
        //public int ProductCount { get; set; }





    }
}
