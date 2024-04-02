namespace PerfumeryStore.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public Address? Address { get; set; }
        public ShippingType Type { get; set; }
        public DateTime? DeliverDate {  get; set; }
    }
    public enum ShippingType
    {
        PickUp,
        NovaPoshta
    }
}
