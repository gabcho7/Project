using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DrinkShop.Data.Models;
using DrinkShop.Services;
using DrinkShop.Web.Models.ManageViewModels;

namespace DrinkShop.Data.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly IShoppingCartManager _sm;

        public HomeController(IDrinkRepository drinkRepository, IShoppingCartManager sm)
        {
            _drinkRepository = drinkRepository;
            this._sm = sm;
        }

        public ViewResult Index()
        {
            var indexViewModel = new IndexViewModel
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            };
            return View(indexViewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
