using DrinkShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkShop.Services.Models
{
   public class CartItem
    {
        public Drink Drink { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }
}
