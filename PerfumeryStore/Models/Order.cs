using System.Collections;
using System.Collections.Generic;

namespace PerfumeryStore.Models
{
    public class Order
    {
        public Guid? Id {  get; set; }
        public string OrderNumber {get;set;}=string.Empty;

        public Customer? Customer { get;set;}
        public Shipping? Sheppment { get; set; }
        public List<Product> Products { get; set; } = [];
        public List<Total> Totals { get; set; }= [];
        public DateTime? OrderDate { get; set; }
        public List<Paymant> Paymants {  get; set; }= [];
    }
}
