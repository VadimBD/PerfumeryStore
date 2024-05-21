using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PerfumeryStore.Infrastucture;
using PerfumeryStore.Models;
using PerfumeryStore.Models.Interfaces;
using PerfumeryStore.Models.ViewModels;
using System.Security.Claims;

namespace PerfumeryStore.Controllers
{
    [Authorize]
    public class OrderController: Controller
    {
        private readonly Cart cart;
        private readonly IOrderRepository _repository;
        private readonly Utils _utils;

        public OrderController(IOrderRepository repoService, Cart CartService, Utils utils)
        {
            _repository = repoService;
            cart = CartService;
            _utils = utils;
        }

        
        public ViewResult Checkout()
        {
            var orderVM = new OrderViewModel() 
            { 
                Order = new Order() {
                    Total = cart.ComputeTotalValue(),
                    Lines = cart.Lines.ToArray(),
                }
            };
           
            return View(orderVM);
        } 

        [HttpPost]
        public IActionResult Checkout(OrderViewModel orderVM)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            var order = orderVM.Order;
            order.Lines = cart.Lines.ToArray();
            order.Total = cart.ComputeTotalValue();

            if (ModelState.IsValid)
            {
                order.UserId = new Guid(_utils.GetCurrentUserId());
                _repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed),new { orderNumber = order.OrderNumber });
            }
            else
            {
                return View(orderVM);
            }
        }

        public ViewResult Completed(int orderNumber)
        {
            cart.Clear();
            return View(orderNumber);
        }

        [HttpGet]
        public ViewResult OrderList()
        {
            var currentUserId = new Guid( _utils.GetCurrentUserId());
            var orders = _repository.Orders.Where(o => o.UserId == currentUserId).ToList();
            return View(orders);
        }
        public ViewResult OrderDetails(Guid orderId)
        {
            var order= _repository.Orders.FirstOrDefault(o=>o.Id == orderId);
            return View(order);
        }
    }
}
