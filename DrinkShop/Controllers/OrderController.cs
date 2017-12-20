
using DrinkShop.Data.Models;
using DrinkShop.Services;
using DrinkShop.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Checkout(string address, string firstName, string lastName, string city, string country, string phoneNumber, string email)
        {
            if (ModelState.IsValid)
            {
                _orderManager.CheckoutCart(address, firstName, lastName, city, country, phoneNumber, email);
                return RedirectToAction("CheckoutComplete");
            }
            return RedirectToAction(nameof(Checkout));
            
    }

    public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Your order has been received!";
            return View();
        }
    }
}
