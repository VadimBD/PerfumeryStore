using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfumeryStore.Models;
using PerfumeryStore.Models.Interfaces;
using PerfumeryStore.Models.ViewModels;

namespace PerfumeryStore.Controllers
{
    [Authorize]
    public class OrderController: Controller
    {
        private Cart cart;
        private IOrderRepository _repository;

        public OrderController(IOrderRepository repoService, Cart CartService)
        {
            _repository = repoService;
            cart = CartService;
        }

        
        public ViewResult Checkout()
        {
            var orderVM = new OrderViewModel() 
            { 
                Order = _repository.CreateNewOrder() 
            };
           
            return View(orderVM);
        } 

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                _repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}
