using Microsoft.AspNetCore.Identity;
using PerfumeryStore.Models.Interfaces;
using PerfumeryStore.Areas.Identity.Data;
using System.Security.Claims;

namespace PerfumeryStore.Models
{
    public class FakeOrderRepository : IOrderRepository
    {
        private readonly UserManager<PerfumeryStoreUser> _usernManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IEnumerable<Order> Orders => [];

        public FakeOrderRepository(UserManager<PerfumeryStoreUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _usernManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public Order CreateNewOrder()
        {
            ClaimsPrincipal? user = _httpContextAccessor?.HttpContext?.User ?? throw new Exception("Can not get User");
            var userId = _usernManager.GetUserId(user);
            if (string.IsNullOrWhiteSpace(userId))
                throw new Exception("Can not get UserId");

            return new Order() { UserId = new Guid(userId) };
        }

        public void SaveOrder(Order order)
        {
           
        }
    }
}
