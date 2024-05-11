namespace PerfumeryStore.Models.ViewModels
{
    public class ProductFilterViewModel
    {
        public List<Brand> Brands { get; set; } = [];
        public List<int> SelectedBrands { get; set; } = [];
        public Gender? SelectedGender { get; set; } 
        public List<ProductType> SelectedProductTypes { get; set; } = [];
      
    }
}

