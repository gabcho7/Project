
using System;
using System.Collections.Generic;
using System.Text;
using DrinkShop.Data.Models;
using DrinkShop.Data;
using System.Linq;

namespace DrinkShop.Services.Implementations
{
    public class CategoryManager : ICategoryManager
    {

        private readonly ApplicationDbContext db;

        public CategoryManager(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return this.db.Categories.ToList();
        }

        //public bool Create()
        //{

        //    return true;
        //}
    }
}
