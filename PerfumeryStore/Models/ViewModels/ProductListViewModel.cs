namespace PerfumeryStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public List<int> BrandsId { get; set; } = [];
        public List<ProductType> ProductTypes { get; set; } = [];
        public Gender? Gender { get; set; }
        public PagingInfoVM? PagingInfo { get; set; }
    }
}
