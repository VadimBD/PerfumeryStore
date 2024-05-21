using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfumeryStore.Infrastucture;
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
        Utils _utils;
        public ProductController(IProductRepository productRepository,Utils utils)
        {
            _productRepository = productRepository;
            pageSize = 9;
            _utils = utils;
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
        [Authorize]
        public IActionResult AddReview(string newReview,int productId)
        {
            var review = new Review() { ReviewText = newReview, UserId=new Guid(_utils.GetCurrentUserId()) };
            var product = _productRepository.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.Reviews.Add(review);
                _productRepository.SaveProduct(product);
            }
            return RedirectToAction("ProductInfo", new {id=productId});
        }
    }
}
