using BakeryShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingcart;
        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingcart = shoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingcart.GetShoppingCartItems();
            _shoppingcart.ShoppingCartItems = items;
            if (items.Count==0)
            {
                ModelState.AddModelError("empty", "You have to add some items to your shopping cart first.");
            }
            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingcart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for choosing us, we hope to see you again.";
            return View();
        }
    }
}
