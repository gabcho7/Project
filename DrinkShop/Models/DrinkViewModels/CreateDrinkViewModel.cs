using DrinkShop.Data.Models;
using System.Collections.Generic;

namespace DrinkShop.Web.Models.DrinkViewModels
{
    public class CreateDrinkViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
