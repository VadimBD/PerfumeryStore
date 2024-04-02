namespace PerfumeryStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public Revie? Revie { get; set; }
        public string Article { get; set; } = string.Empty;
        public Brand? Brand { get; set; }
        public ProductСontainer? Container { get; set; }
        public ProductType ProductType { get; set; }
        public Gender Gender { get; set; }
    }
    public enum ProductType
    {

    }
    public enum Gender
    {
        Male,
        Female,
        Another
    }
  
    public class ProductСontainer
    {
        public int Id { get; set;}
        public string Name { get; set;} = string.Empty;
        public string DisplayName { get; set;} = string.Empty;
    }

}


