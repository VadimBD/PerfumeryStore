using Microsoft.AspNetCore.Mvc;

namespace PerfumeryStore.Controllers
{
    public class HomeController:Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
    }
}
