namespace PerfumeryStore.Models.Interfaces
{
    public interface IProductRepositorie
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);
        Product DeleteProduct(Product product);

    }
}
