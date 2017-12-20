using DrinkShop.Data.Models;
using DrinkShop.Web.Models.ShoppingCartViewModels;
using DrinkShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DrinkShop.Services.Models;
using DrinkShop.Web.Infrastructure.Extentions;
using DrinkShop.Data;

namespace DrinkShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartManager shoppingCartManager;
        private readonly ApplicationDbContext db;


        public ShoppingCartController(IShoppingCartManager shoppingCartManager, ApplicationDbContext db)
        {
            this.shoppingCartManager = shoppingCartManager;
            this.db = db;

        }

        public IActionResult MyCart()
        {
            var cart = shoppingCartManager.GetCart();
            return View(new ShoppingCartViewModel() { CartItems = cart.Items, ShoppingCartTotal = cart.Total });
        }

        public IActionResult AddToCart(int DrinkId, int quantity = 1)
        {
            Drink drink = db.Drinks.First(d => d.DrinkId == DrinkId);
            CartItem cartItem = shoppingCartManager.CreateCartItem(drink, quantity);
            this.shoppingCartManager.AddToCart(cartItem);
            return RedirectToAction(nameof(MyCart));
        }

        public IActionResult RemoveFromCart(int DrinkId)
        {
            Drink drink = db.Drinks.First(d => d.DrinkId == DrinkId);
            this.shoppingCartManager.RemoveFromCart(drink);
            return RedirectToAction(nameof(MyCart));
        }

        [HttpPost]
        public IActionResult UpdateItem(int drinkId, int quantity)
        {
            Drink drink = db.Drinks.First(d => d.DrinkId == drinkId);
            shoppingCartManager.UpdateItem(drink, quantity);
            return RedirectToAction(nameof(MyCart));
        }

    }
}

