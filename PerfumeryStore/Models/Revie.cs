namespace PerfumeryStore.Models
{
    public class Revie
    {
        public int Id { get; set; }
        public Guid UserId { get; init; }
        public string RevieText { get; set; } = string.Empty;
    }
}
