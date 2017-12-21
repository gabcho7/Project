using DrinkShop.Data.Models;
using System.Collections.Generic;

namespace DrinkShop.Web.Models.DrinkViewModels
{
    public class DrinkListViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }

        public string CurrentCategory { get; set; }

       
    }
}
