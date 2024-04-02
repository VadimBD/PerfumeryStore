namespace PerfumeryStore.Models
{
    public class Revie
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public string RevieText { get; set; } = string.Empty;
    }
}
