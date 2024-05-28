namespace PerfumeryStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Review> Reviews { get; set; } = [];
        public string Article { get; set; } = string.Empty;
        public Brand? Brand { get; set; }
        public ProductСontainer? Container { get; set; }
        public ProductType ProductType { get; set; }
        public Gender Gender { get; set; }
        public bool TopSales {  get; set; }
        public bool Novelty {  get; set; }
        public string Image { get; set; } = string.Empty;
    }
    public enum ProductType
    {
        Parfum=1,
        EauDeParfum=2,
        EauDeToilette=3,
        EauDeCologne=4,
        Tester=5,
        Вeodorant=6
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Another = 3
    }
  
    public class ProductСontainer
    {
        public int Id { get; set;}
        public string Name { get; set;} = string.Empty;
        public string DisplayName { get; set;} = string.Empty;
    }

}


