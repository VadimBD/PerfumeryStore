using PerfumeryStore.Models.Interfaces;

namespace PerfumeryStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products => 
            [
            new Product(){ Id=1,Name="Product1",Price=123243,Brand= new(){Name="Perfumeri Brend" },TopSales=true,Image="./images/TestPhoto.jpg"},
            new Product(){ Id=1,Name="Product2",Price=123243,Brand= new(){Name="Perfumeri Brend" },TopSales=true,Image="./images/TestPhoto.jpg"},
            new Product(){Id=1,Name="Product3",Price=(float)2325.767,Brand= new(){Name="Perfumeri Brend" },TopSales=true,Image="./images/TestPhoto.jpg"},
            new Product(){Id=1,Name="Product4",Price=(float)2325.767,Brand= new(){Name="Perfumeri Brend" },TopSales=true,Image="./images/TestPhoto.jpg"},
            new Product(){Id=1,Name="Product5",Price=(float)2325.767,Brand= new(){Name="Perfumeri Brend" },TopSales=true,Image="./images/TestPhoto.jpg"},
            new Product(){Id=1,Name="Product6",Price=(float)2325.767,Brand= new(){Name="Perfumeri Brend" },TopSales=true,Image="./images/TestPhoto.jpg"},
            ];

        public IEnumerable<Brand> Brands =>[];

        public Product DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
