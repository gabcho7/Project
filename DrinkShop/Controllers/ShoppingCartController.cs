using DrinkShop.Data.Models;
using DrinkShop.Web.Models.ShoppingCartViewModels;
using DrinkShop.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace DrinkShop.Web.Controllers
//{
    //public class ShoppingCartController : Controller
    //{
    //    private readonly IDrink _drinkRepository;
    //    private readonly ShoppingCart _shoppingCart;

    //    public ShoppingCartController(IDrink drinkRepository, ShoppingCart shoppingCart)
    //    {
    //        _drinkRepository = drinkRepository;
    //        _shoppingCart = shoppingCart;
    //    }

        //[Authorize]
        //public IActionResult Index()
        //{
        //    var items = _shoppingCart.GetShoppingCartItems();
        //    _shoppingCart.CartItems = items;

        //    var shoppingCartViewModel = new ShoppingCartViewModel
        //    {
        //        ShoppingCart = _shoppingCart,
        //        ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        //    };
        //    return View(shoppingCartViewModel);
        //}

        //[Authorize]
    //    public RedirectToActionResult AddToShoppingCart(int drinkId)
    //    {
    //        var selectedDrink = _drinkRepository.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);
    //        if (selectedDrink != null)
    //        {
    //            _shoppingCart.AddToCart(selectedDrink, 1);
    //        }
    //        return RedirectToAction("Index");
    //    }

    //    public RedirectToActionResult RemoveFromShoppingCart(int drinkId)
    //    {
    //        var selectedDrink = _drinkRepository.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);
    //        if (selectedDrink != null)
    //        {
    //            _shoppingCart.RemoveFromCart(selectedDrink);
    //        }
    //        return RedirectToAction("Index");
    //    }
    //}
//}

