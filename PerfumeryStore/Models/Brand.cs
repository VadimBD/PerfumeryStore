namespace PerfumeryStore.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DisplayName {get;set; } = string.Empty;
        public string Discription {get;set; } = string.Empty;

        public Brand() 
        {
            
        }
       public Brand(int brandId, string name, string displayName, string discription)
       {
            Id = brandId;
            Name = name;
            DisplayName = displayName;
            Discription = discription;
       }
    }
}
