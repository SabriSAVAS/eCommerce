using eCommerce.Dto.Attributes;
using eCommerce.Dto.Category;
using eCommerce.Dto.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace eCommerce.Dto.Product
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            BrandList = new List<SelectListItem>();
            VatList = new List<SelectListItem>();
            CategoryList = new List<SelectListItem>();
          
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen bir isim girin.")]
        public string Name { get; set; }
        public string Seo { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        [StringLength(400)]
        public string Sku { get; set; }
        [Required(ErrorMessage = "Lütfen adet girin.")]
        public int Qunatity { get; set; }  
        public decimal OldPrice { get; set; }
        [Required(ErrorMessage = "Lütfen fiyat girin.")]
        public decimal Price { get; set; }        
        public decimal ProductCost { get; set; }
        public List<SelectListItem> VatList { get; set; }

        [Required(ErrorMessage = "Lütfen kdv girin.")]
        public decimal Vat { get; set; }
        public List<SelectListItem> BrandList { get; set; }
        [Required(ErrorMessage = "Lütfen marka girin.")]
        public int BrandId { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public bool IsFreeShipping { get; set; }
        public bool ShowOnHomePage { get; set; }
        public bool Published { get; set; }


        //Tags
        public string ProductTags { get; set; }


        //Category
        public int? CategoryId { get; set; }
        public List<SelectListItem> CategoryList { get; set; }


        
    }
}
