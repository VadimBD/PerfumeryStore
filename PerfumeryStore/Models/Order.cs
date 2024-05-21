using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfumeryStore.Models
{
    public class Order
    {
        public Guid? Id {  get; set; }
        [Required]
        public Guid UserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber {get;set;}
        public Shipping Sheppment { get; set; } =new Shipping();
        public IEnumerable<CartLine> Lines { get; set; } = [];
        public float Total { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
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
