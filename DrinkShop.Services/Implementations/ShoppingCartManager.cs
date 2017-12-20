using System;
using System.Collections.Generic;
using System.Text;
using DrinkShop.Services.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using DrinkShop.Data.Models;

namespace DrinkShop.Services.Implementations
{   
    public class ShoppingCartManager : IShoppingCartManager
    {
        public const string sessionCartIdentifier = "ShoppingCartId";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        private readonly IDictionary<string, ShoppingCart> _shoppingCartDictionary;
        
        public ShoppingCartManager(IHttpContextAccessor httpContextAccessor)
        {
            
            _shoppingCartDictionary = new Dictionary<string, ShoppingCart>();
            
            _httpContextAccessor = httpContextAccessor;
           
        }
        public ShoppingCart GetCart()
        {
            ShoppingCart cart = new ShoppingCart();
            string cartId = _session.GetString(sessionCartIdentifier);
            if (cartId != null)
            {
                 _shoppingCartDictionary.TryGetValue(cartId, out cart);
            }
            else
            {
                cartId = Guid.NewGuid().ToString().Substring(0, 8);
                cart.Id = cartId;
                _session.SetString(sessionCartIdentifier, cartId);
                _shoppingCartDictionary.Add(cartId, cart);
            }
            return cart;
        }
        public void AddToCart(CartItem cartItem)
        {
            ShoppingCart cart = this.GetCart();
            var item = cart.Items.Find(itm => itm.Drink.DrinkId == cartItem.Drink.DrinkId);
            if (item == null)
            {
                cart.Items.Add(cartItem);
            }
            else
            {
                item.Quantity += cartItem.Quantity;

            }
            this.UpdateCart();
        }

        public void ClearCart()
        {
            this.GetCart().Items.Clear();
            this.UpdateCart();
        }
        public void UpdateItem(Drink drink, int quantity)
        {
            ShoppingCart cart = this.GetCart();
            var item = cart.Items.Find(itm => itm.Drink.DrinkId == drink.DrinkId);
            item.Quantity = quantity;
            item.Price = quantity * item.Drink.Price;
            this.UpdateCart();
        }

        public void RemoveFromCart(Drink drink)
        {
            ShoppingCart cart = this.GetCart();
            var item = cart.Items.Find(itm => itm.Drink.DrinkId == drink.DrinkId);
            if(item != null)
            {
                cart.Items.Remove(item);
            }
            this.UpdateCart();
        }
        public CartItem CreateCartItem(Drink drink, int quantity)
        {
            return new CartItem() { Drink = drink, Price = drink.Price * quantity, Quantity = quantity };
        }
        private void UpdateCart()
        {
            var cart = GetCart();
            cart.Total = cart.Items.Sum(itm => itm.Price);
        }
    }
}
