using DrinkShop.Data;
using DrinkShop.Data.Models;
using DrinkShop.Services.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkShop.Services.Implementations
{
    public class AdminDrinkService : IAdminDrinkService
    {
        private readonly ApplicationDbContext db;

        public AdminDrinkService (ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(
            string name,
            string shortDescription, 
            string longDescription, decimal price, 
            string imageUrl, 
            string imageThumbnail, 
            bool isPreferredDrink, 
            bool inStock, 
            int categoryId)
        {
            var drink = new Drink
            {
                Name = name,
                ShortDescription = shortDescription,
                LongDescription = longDescription,
                ImageUrl = imageUrl,
                ImageThumbnail = imageThumbnail,
                IsPreferredDrink = isPreferredDrink,
                InStock = inStock,
                CategoryId = categoryId
            };

            this.db.Add(drink);
            this.db.SaveChanges();
        }
    }
}
