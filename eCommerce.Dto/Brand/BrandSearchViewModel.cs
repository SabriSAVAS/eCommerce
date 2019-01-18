using PagedList;

namespace eCommerce.Dto.Brand
{
    public  class BrandSearchViewModel
    {
        public string BrandName { get; set; }
        public int? Page { get; set; }
        public IPagedList<BrandListViewModel> BrandList { get; set; }
    }
}
