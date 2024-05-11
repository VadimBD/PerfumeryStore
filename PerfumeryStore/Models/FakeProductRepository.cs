using PerfumeryStore.Models.Interfaces;

namespace PerfumeryStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products => 
            [
            new Product(){ Id=1,Name="Product1",Price=123243,Brand= new(){Name="Perfumeri Brend1" , Id=1 },TopSales=true,Image="/images/TestPhoto.jpg"},
            new Product(){ Id=2,Name="Product2",Price=123243,Brand= new(){Name="Perfumeri Brend2" ,Id=2},TopSales=true,Image="/images/TestPhoto.jpg"},
            new Product(){Id=3,Name="Product3",Price=(float)2325.767,Brand= new(){Name="Perfumeri Brend3" ,Id=3},TopSales=true,Image="/images/TestPhoto.jpg"},
            new Product(){Id=4,Name="Product4",Price=(float)2325.767,Brand= new(){Name="Perfumeri Brend3" ,Id=3},TopSales=true,Image="/images/TestPhoto.jpg"},
            new Product(){Id=5,Name="Product5",Price=(float)2325.767,Brand= new(){Name="Perfumeri Brend5" ,Id=5 },TopSales=true,Image="/images/TestPhoto.jpg"},
            new Product(){Id=6,Name="Product6",Price=(float)2325.767,Brand= new(){Name="Perfumeri Brend6" ,Id=6},TopSales=true,Image="/images/TestPhoto.jpg"},
            new Product(){ Id=7,Name="Product1",Price=123243,Brand= new(){Name="Perfumeri Brend7" ,Id=7},TopSales=true,Image="/images/TestPhoto.jpg"},
             new Product(){ Id=8,Name="Product1",Price=123243,Brand= new(){Name="Perfumeri Brend8" ,Id=8},TopSales=true,Image="/images/TestPhoto.jpg"},
             new Product(){ Id=9,Name="Product1",Price=123243,Brand= new(){Name="Perfumeri Brend9" ,Id=9},TopSales=true,Image="/images/TestPhoto.jpg"},
            ];

        public IEnumerable<Brand> Brands =>Products.Select(e=>e.Brand);

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
