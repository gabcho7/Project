using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkShop.Services.Models
{
    public class ShoppingCart
    {
        public string Id { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Total { get; set; }
        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        //public IEnumerable<CartItem> CartItems => new List<CartItem>(this.Items);

        //public void AddToCart(CartItem item)
        //{
        //    this.Items.Add(item);
        //}
    }
}
