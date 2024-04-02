namespace PerfumeryStore.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
    }
}
