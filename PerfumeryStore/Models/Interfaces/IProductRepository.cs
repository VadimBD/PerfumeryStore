namespace PerfumeryStore.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Brand> Brands { get; }
        
       void SaveReview(Review review, int productId);
    }
}
