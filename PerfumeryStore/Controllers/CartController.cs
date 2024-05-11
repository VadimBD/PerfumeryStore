using Microsoft.AspNetCore.Mvc;
using PerfumeryStore.Models.Interfaces;
using PerfumeryStore.Models;
using PerfumeryStore.Models.ViewModels;

namespace PerfumeryStore.Controllers
{
    public class CartController: Controller
    {
        private IProductRepository repository;
        private Cart cart;

        public CartController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public RedirectToActionResult AddToCart(int Id, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
