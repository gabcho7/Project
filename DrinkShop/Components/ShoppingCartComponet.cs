using DrinkShop.Data.Models;
using DrinkShop.Web.Models.ShoppingCartViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.Web.Components
{
    [ViewComponent]


    public class ShoppingCartComponent : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartComponent(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = new List<CartItem>() { new CartItem(), new CartItem() }/*_shoppingCart.GetShoppingCartItems()*/;
            _shoppingCart.CartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
    }
}
