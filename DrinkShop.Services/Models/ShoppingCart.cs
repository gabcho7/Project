using System.Collections.Generic;

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

    }
}
