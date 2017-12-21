using DrinkShop.Data.Models;
using DrinkShop.Services;
using DrinkShop.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DrinkShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;
       

        public OrderController(IOrderManager orderManager
            )
        {
            _orderManager = orderManager;
        }

        [Authorize]
        public IActionResult Checkout()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            { 
                
                _orderManager.CheckoutCart(order.Address, order.FirstName, order.LastName, order.City, order.Country, order.PhoneNumber, order.Email);
                return RedirectToAction("CheckoutComplete");
            }
        
            return View(order);
            
    }

    public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Your order has been received!";
            return View();
        }
    }
}
