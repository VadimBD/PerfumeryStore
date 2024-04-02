namespace PerfumeryStore.Models
{
    public class Paymant
    {
        public int Id { get; set; }
        public PaymantType Type { get; set; }
        public PaymentStatuse Status { get; set; }
        public DateTime InsertedDate { get; set; }
        public float Amount { get; set; }
    }
    public enum PaymantType
    {

    }
    public enum PaymentStatuse
    {
        
    }
}
