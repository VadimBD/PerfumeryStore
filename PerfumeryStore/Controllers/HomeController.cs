using Microsoft.AspNetCore.Mvc;
using PerfumeryStore.Models;
using PerfumeryStore.Models.Interfaces;
using PerfumeryStore.Models.ViewModels;
using System.Runtime.CompilerServices;

namespace PerfumeryStore.Controllers
{
    public class HomeController:Controller
    {
        IProductRepository _productRepository;
        IConfiguration _config;
        Random _random;
       public HomeController(IProductRepository productRepository,IConfiguration config)
        {
            _productRepository = productRepository;
            _config = config;
            _random = new();
        }
        [HttpGet]
        public ViewResult Index()
        {

            var vm=new LendingViewModel();
            var topSalesPP =int.TryParse(_config["TopSalesPerPage"],out var result)? result:4;
            var noveltysPP = int.TryParse(_config["NoveltyPerPage"], out var result1) ? result : 4;

            IEnumerable<Product> rndRange(List<Product> products, int count)
            {
                if (products.Count <= count)
                    return products;

                var list =new List<Product>();
                for (var i = 0; i < count; i++)
                {
                    list.Add( products[_random.Next(0, products.Count())]);
                }
                return list;
            }
            vm.TopSales = rndRange(_productRepository.Products.Where(p => p.TopSales == true).ToList(), topSalesPP);
            vm.Noveltys = rndRange(_productRepository.Products.Where(_p => _p.Novelty == true).ToList(), noveltysPP);
            return View("Index", vm);
        }
    }
}
