using DrinkShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DrinkShop.Services
{
   public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
