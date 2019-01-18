namespace eCommerce.Dto.ProductAttributeMapping
{
    public class ProductAttributeMappingListViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string ProductAttribute { get; set; }
        public int AttributeControlTypeId { get; set; }
        public string TextPrompt { get; set; }
    }
}
