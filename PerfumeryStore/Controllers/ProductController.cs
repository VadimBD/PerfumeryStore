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
            pageSize = 2;
        }



        [HttpGet]
        public ViewResult List(string brands,string productTypes, Gender? gender,int page=1)
        {
            var brandsList=!string.IsNullOrWhiteSpace(brands)? brands.Split(',').Cast<int>().ToList(): [];
            var typeList=!string.IsNullOrWhiteSpace(productTypes)? productTypes.Split(",").Cast<ProductType>().ToList():[];
            var productList = _productRepository.Products.Where(p => (typeList.Count < 1 || typeList.Contains(p.ProductType)) &&
             (brandsList.Count < 1 || brandsList.Contains(p.Id)) &&
             (!gender.HasValue || p.Gender == gender.Value));
            var productsVM = new ProductListViewModel(); 
            productsVM.Products = productList.OrderBy(p=>p.Id).Skip((page-1)*pageSize).Take(pageSize);
            productsVM.PagingInfo = new() { CurrentPage=page, ItemsPerPage=pageSize, TotalItems= productList.Count()};
            productsVM.Gender = gender;
            productsVM.BrandsId = brandsList;
            productsVM.ProductTypes = typeList;


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
    }
}
