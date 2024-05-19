namespace PerfumeryStore.Models.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
        Order CreateNewOrder();
    }
}
