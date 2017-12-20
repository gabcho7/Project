using DrinkShop.Data.Models;
using DrinkShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.Web.Models.ShoppingCartViewModels
{
    public class ShoppingCartViewModel
    { 
        public ShoppingCart ShoppingCart { get;set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal ShoppingCartTotal { get; set; }

    }
}
