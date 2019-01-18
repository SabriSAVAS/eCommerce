using PagedList;
namespace eCommerce.Dto.ReletedProduct
{
    public class RelatedProductSearchViewModel
    {
        public string ProductName { get; set; }
        public int? Page { get; set; }
        public IPagedList<RelatedProductListViewModel> RelatedProductList { get; set; }
    }
}
