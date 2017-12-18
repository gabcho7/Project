using DrinkShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.Web.Models.DrinkViewModels
{
    public class CreateDrinkViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
