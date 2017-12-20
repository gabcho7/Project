using DrinkShop.Data.Models;
using DrinkShop.Web.Models.DrinkViewModels;
using DrinkShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.Data.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrink _drinkRepository;
        private readonly ICategory _categoryRepository;

        public DrinkController(IDrink drinkRepository, ICategory categoryRepository)
        {
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;
        }


        //public ViewResult List()
        //{

        //    DrinkListViewModel vm = new DrinkListViewModel();
        //    vm.Drinks = _drinkRepository.Drinks;
        //    //_drinkRepository.Seed();
        //    vm.CurrentCategory = "DrinkCategory";

        //    return View(vm);
        //}




        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(p => p.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase))
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.Name.Equals("Alcoholic")).OrderBy(p => p.Name);
                else
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.Name.Equals("Non-alcoholic")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            });
        }

        //    public ViewResult Search(string searchString)
        //    {
        //        string _searchString = searchString;
        //        IEnumerable<Drink> drinks;
        //        string currentCategory = string.Empty;

        //        if (string.IsNullOrEmpty(_searchString))
        //        {
        //            drinks = _drinkRepository.Drinks.OrderBy(p => p.DrinkId);
        //        }
        //        else
        //        {
        //            drinks = _drinkRepository.Drinks.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
        //        }

        //        return View("~/Views/Drink/List.cshtml", new DrinksListViewModel { Drinks = drinks, CurrentCategory = "All drinks" });
        //    }

        public ViewResult Details(int drinkId)
        {
            var drink = _drinkRepository.Drinks.FirstOrDefault(d => d.DrinkId == drinkId);
            if (drink == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(drink);
        }
        //}
    }
}

