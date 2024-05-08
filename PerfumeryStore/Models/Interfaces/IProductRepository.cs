namespace PerfumeryStore.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Brand> Brands { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(Product product);

    }
}
