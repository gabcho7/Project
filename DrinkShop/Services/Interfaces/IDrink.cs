using DrinkShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.Web.Services.Interfaces
{
    public interface IDrink
    {
        IEnumerable<Drink> Drinks { get; }

        IEnumerable<Drink> GetPreferredDrinks { get; }

        Drink GetDrinkById(int drinkId);

        //void Seed();
    }
}
