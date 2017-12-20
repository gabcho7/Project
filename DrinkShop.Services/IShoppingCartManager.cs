using DrinkShop.Data.Models;
using DrinkShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkShop.Services
{
    public interface IShoppingCartManager
    {
        ShoppingCart GetCart();
        void AddToCart(CartItem cartItem);
        void RemoveFromCart(Drink drink);
        void ClearCart();
        CartItem CreateCartItem(Drink drink, int quantity);
        void UpdateItem(Drink drink, int quantity);
    }
}
