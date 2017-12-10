﻿namespace DrinkShop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        //public ShoppingCart Cart { get; set; }
        //public int CartId { get; set; }
    }
}
