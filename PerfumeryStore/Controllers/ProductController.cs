using Microsoft.AspNetCore.Mvc;
using PerfumeryStore.Models;
using PerfumeryStore.Models.Interfaces;
using PerfumeryStore.Models.ViewModels;
using System.Linq;

namespace PerfumeryStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private int pageSize;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            pageSize = 9;
        }



        [HttpGet]
        public ViewResult List(List<int> brand, List<ProductType> type, Gender? gender, int page = 1)
        {
            var productList = _productRepository.Products.Where(p => (type.Count < 1 || type.Contains(p.ProductType)) &&
             (brand.Count < 1 || brand.Contains(p.Brand.Id)) &&
             (!gender.HasValue || p.Gender == gender.Value));

            var productsVM = new ProductListViewModel()
            {
                Products = productList.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new() { CurrentPage = page, ItemsPerPage = pageSize, TotalItems = productList.Count() },
                Gender = gender,
                BrandsId = brand,
                ProductTypes = type
            };

            return View("Products", productsVM);
        }

        [HttpGet]
        public ViewResult ProductInfo(int id)
        {
           var product=_productRepository.Products.FirstOrDefault(p => p.Id == id);
            return View("AboutProduct", product);
        }
        [HttpGet]
        public ViewResult Brands(int id) 
        {
            if (id>0)
                return View("BrandInfo", _productRepository.Brands.FirstOrDefault(b=>b.Id==id));
            else
                return View("Brands", _productRepository.Brands);
        }
        [HttpGet]
        public ViewResult BrandInfo(int id) 
        {
            var brand= _productRepository.Brands.FirstOrDefault(b => b.Id == id);
            return View(brand);
        }
        
    }
}
