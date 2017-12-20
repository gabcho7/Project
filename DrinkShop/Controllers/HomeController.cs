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
        private readonly IDrink _drinkRepository;
        private readonly IShoppingCartManager _sm;

        public HomeController(IDrink drinkRepository, IShoppingCartManager sm)
        {
            _drinkRepository = drinkRepository;
            this._sm = sm;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        public ViewResult Index()
        {
            var indexViewModel = new IndexViewModel
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            };
            return View(indexViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
