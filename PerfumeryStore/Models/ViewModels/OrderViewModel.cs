using Microsoft.AspNetCore.Mvc.Rendering;

namespace PerfumeryStore.Models.ViewModels
{
    public class OrderViewModel
    {
        public Order Order {get;set;}
        public IEnumerable<SelectListItem> ShippingTypeSLI => Enum.GetValues<ShippingType>().Select(i => new SelectListItem() { Value =  ((int)i).ToString(), Text= i.ToString() });
    }
}
