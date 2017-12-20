using DrinkShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkShop.Services
{
   public interface ICategoryManager
    {
        IEnumerable<Category> GetAllCategories();
        //bool Create();
    }
}
