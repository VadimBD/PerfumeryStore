namespace PerfumeryStore.Models
{
    public class Total
    {
        public int Id { get; set; }
        public TotalType Type { get; set; }
        public float value { get; set; }
    }
    public enum TotalType
    {
        retail,
        ajustment,
        summary
    }
}
