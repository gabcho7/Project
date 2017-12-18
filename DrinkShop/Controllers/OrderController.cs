
using DrinkShop.Data.Models;
using DrinkShop.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrinkShop.Web.Controllers
{
    //public class OrderController : Controller
    //{
    //    private readonly IOrder _orderRepository;
    //    private readonly CartItem _shoppingCart;

    //    public OrderController(IOrder orderRepository, CartItem shoppingCart)
    //    {
    //        _orderRepository = orderRepository;
    //        _shoppingCart = shoppingCart;
    //    }

    //    [Authorize]
    //    public IActionResult Checkout()
    //    {
    //        return View();
    //    }

        //[HttpPost]
        //[Authorize]
        //public IActionResult Checkout(Order order)
        //{
        //    var items = _shoppingCart.GetShoppingCartItems();
        //    _shoppingCart.CartItems = items;
        //    if (_shoppingCart.CartItems.Count == 0)
        //    {
        //        ModelState.AddModelError("", "Your card is empty, add some drinks first");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _orderRepository.CreateOrder(order);
        //        _shoppingCart.ClearCart();
        //        return RedirectToAction("CheckoutComplete");
        //    }

        //    return View(order);
        //}

        //public IActionResult CheckoutComplete()
        //{
        //    ViewBag.CheckoutCompleteMessage = "Thanks for your order! :) ";
        //    return View();
        //}
    }
//}
