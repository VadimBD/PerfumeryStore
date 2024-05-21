using Microsoft.AspNetCore.Identity;
using PerfumeryStore.Models.Interfaces;
using PerfumeryStore.Areas.Identity.Data;
using System.Security.Claims;

namespace PerfumeryStore.Models
{
    public class FakeOrderRepository : IOrderRepository
    {
        private int _orderNumber = 1;
        private List<Order> _orders=new();
        public IEnumerable<Order> Orders =>_orders;

        public FakeOrderRepository()
        {

        }

        public void SaveOrder(Order order)
        {
            order.Id = Guid.NewGuid();
            order.OrderDate = DateTime.Now;
            order.OrderNumber = _orderNumber;
            _orderNumber++;
            _orders.Add(order);
        }
    }
}
