using eCommerce.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Domain.Context
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext() : base("DbServer")
        {
            Database.SetInitializer<eCommerceContext>(new DropCreateDatabaseIfModelChanges<eCommerceContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<ProductTag> ProductTag { get; set; }
        public DbSet<ProductCategoryMapping> ProductCategoryMapping { get; set; }
        public DbSet<ProductPictureMapping> ProductPictureMapping { get; set; }
        public DbSet<ProductTagMapping> ProductTagMapping { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<DiscountAppliedToCategories> DiscountAppliedToCategories { get; set; }
        public DbSet<DiscountAppliedToProducts> DiscountAppliedToProducts { get; set; }
        public DbSet<DiscountUsageHistory> DiscountUsageHistory { get; set; }

        public DbSet<RelatedProduct> RelatedProduct { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public DbSet<ProductAttribute> ProductAttribute { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValue { get; set; }
        public DbSet<ProductAttributeMapping> ProductAttributeMapping { get; set; }
        public DbSet<PredefinedProductAttributeValue> PredefinedProductAttributeValue { get; set; }

        public DbSet<SpecificationAttribute> SpecificationAttribute { get; set; }
        public DbSet<SpecificationAttributeValue> SpecificationAttributeValue { get; set; }
        public DbSet<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMapping { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerRole> CustomerRole { get; set; }
        public DbSet<CustomerRolMapping> CustomerRolMapping { get; set; }
        public DbSet<Address> Adress { get; set; }
        public DbSet<CustomerAddresses> CustomerAddresses { get; set; }
        
    }
}
