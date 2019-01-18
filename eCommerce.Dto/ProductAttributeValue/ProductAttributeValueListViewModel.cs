namespace eCommerce.Dto.ProductAttributeValue
{
    public  class ProductAttributeValueListViewModel
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public int ProductAttributeId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public int OrderNo { get; set; }
    }
}
