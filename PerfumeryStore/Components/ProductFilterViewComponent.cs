using Microsoft.AspNetCore.Mvc;
using PerfumeryStore.Models;
using PerfumeryStore.Models.Interfaces;
using PerfumeryStore.Models.ViewModels;

namespace PerfumeryStore.Components
{
    public class ProductFilterViewComponent:ViewComponent
    {
        private readonly IProductRepository _repository;
        public ProductFilterViewComponent(IProductRepository productRepository)
        {
            _repository= productRepository;
        }
        public IViewComponentResult Invoke(List<int> selectedBrands,Gender? selectedGender,List<ProductType> selectedProductTypes)
        {
            var vm = new ProductFilterViewModel() {
                Brands = _repository.Brands.ToList(),
                SelectedBrands = selectedBrands,
                SelectedGender = selectedGender,
                SelectedProductTypes = selectedProductTypes,
            };
            return View(vm);
        }
    }
}
