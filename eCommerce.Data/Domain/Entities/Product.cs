using eCommerce.Data.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Data.Domain.Entities
{
    [Table("Product")]
    public partial class Product : ModelBase, IAuditableEntity
    {
        public Product()
        {
            ProductCategoryMappings = new List<ProductCategoryMapping>();
            ProductPictureMappings = new List<ProductPictureMapping>();
            ProductTagMappings = new List<ProductTagMapping>();
            DiscountAppliedToProducts = new List<DiscountAppliedToProducts>();
            ProductAttributeMappings = new List<ProductAttributeMapping>();
            ProductSpecificationAttributeMappings = new List<ProductSpecificationAttributeMapping>();
            ProductReviews = new List<ProductReview>();
            
            CreatedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
    }
      
        [Required]
        public string Name { get; set; }
        [Required]
        public string Seo { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        [StringLength(400)]
        public string Sku { get; set; }
        [Required]
        public int Qunatity { get; set; }
        [Required]
        public decimal OldPrice { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal ProductCost { get; set; }
        [Required]
        public decimal Vat { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public bool IsFreeShipping { get; set; }
        public bool ShowOnHomePage { get; set; }//Ana Sayfada Gösterilsin Mi?
        public bool Published { get; set; } // Yayinlansin Mı?


        public DateTime CreatedDate
        { get; set; }

        public int CreatedById
        { get; set; }

        public DateTime? UpdatedDate
        { get; set; }
        public int? UpdatedById
        { get; set; }

        /// <summary>
        /// İlişkiler tablolar arasi
        /// </summary>

        public virtual IList<ProductCategoryMapping> ProductCategoryMappings { get; set; }
        public virtual IList<ProductPictureMapping> ProductPictureMappings { get; set; }
        public virtual IList<ProductTagMapping> ProductTagMappings { get; set; }
        public virtual IList<DiscountAppliedToProducts> DiscountAppliedToProducts { get; set; }
        public virtual IList<ProductAttributeMapping> ProductAttributeMappings { get; set; }
        public virtual IList<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMappings { get; set; }
        public virtual IList<ProductReview> ProductReviews { get; set; }
        public virtual Brand Brand { get; set; }


    }
}
