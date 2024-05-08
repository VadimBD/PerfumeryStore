namespace PerfumeryStore.Models.ViewModels
{
    public class LendingViewModel
    {
        public IEnumerable<Product> TopSales {  get; set; }
        public IEnumerable<Product> Noveltys { get; set; }
    }
}
