using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PerfumeryStore.Models
{
    public class Order
    {
        public Guid? Id {  get; set; }
        [Required]
        public Guid UserId { get; init; }
        public string OrderNumber {get;set;}=string.Empty;
        public Shipping Sheppment { get; set; } =new Shipping();
        public IEnumerable<CartLine> Lines { get; set; } = [];
        public float Totals { get; set; }
        public DateTime? OrderDate { get; set; }
        public List<Paymant> Paymants {  get; set; }= [];
        public OrderStatus OrderStatus { get; set; } = OrderStatus.New;
    }

    public enum OrderStatus
    {
        New=1,
        Shipped=2,
        Delivered=3,
        Complete =4
    }
}
