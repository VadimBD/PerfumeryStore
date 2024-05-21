using Microsoft.AspNetCore.Identity;
using PerfumeryStore.Areas.Identity.Data;
using System.Security.Claims;

namespace PerfumeryStore.Infrastucture
{
    public class Utils
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly UserManager<PerfumeryStoreUser> _usernManager;

        public Utils(IHttpContextAccessor httpContextAccessor,UserManager<PerfumeryStoreUser> usernManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _usernManager = usernManager;
        }

        public virtual string GetCurrentUserId() 
        {
            ClaimsPrincipal? user = _httpContextAccessor?.HttpContext?.User ?? throw new Exception("Can not get User");
            var userId = _usernManager.GetUserId(user);
            if (string.IsNullOrWhiteSpace(userId))
                throw new Exception("Can not get UserId");
            return userId;
        }
    }
}
