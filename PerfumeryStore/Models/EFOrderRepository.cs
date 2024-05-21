using Microsoft.EntityFrameworkCore;
using PerfumeryStore.Models.Interfaces;

namespace PerfumeryStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private AppDBContext _DBContext;
        public EFOrderRepository(AppDBContext dBContext) 
        { 
            _DBContext = dBContext;
        }
        public IEnumerable<Order> Orders => _DBContext.Orders.Include(o=>o.Lines).ThenInclude(l=>l.Product).ThenInclude(p => p.Brand).
            Include(o => o.Lines).ThenInclude(l => l.Product).ThenInclude(p => p.Reviews).
            Include(o => o.Lines).ThenInclude(l => l.Product).ThenInclude(p => p.Container);

        public void SaveOrder(Order order)
        {
            
            if (order.Id == null)
            {
                _DBContext.AttachRange(order.Lines.Select(l => l.Product));
                _DBContext.Orders.Add(order);
            }
            _DBContext.SaveChanges();
        }
    }
}
