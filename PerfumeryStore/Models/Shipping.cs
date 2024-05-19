using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PerfumeryStore.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        [Required]
        public string RecipientName { get; set; } = string.Empty;
        [Required]
        public string DeliveryPoint { get; set; } = string.Empty;
        [Required]
        public ShippingType Type { get; set; }
    }
    public enum ShippingType
    {
        PickUp = 1,
        NovaPoshta = 2
    }
}
