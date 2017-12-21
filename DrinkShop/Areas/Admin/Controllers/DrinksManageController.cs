using DrinkShop.Data;
using DrinkShop.Data.Controllers;
using DrinkShop.Data.Models;
using DrinkShop.Services;
using DrinkShop.Services.Admin;
using DrinkShop.Web.Areas.Admin.Models.Drinks;
using DrinkShop.Web.Infrastructure.Extentions;
using DrinkShop.Web.Models.DrinkViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DrinkShop.Web.Areas.Admin.Controllers
{
    public class DrinksManageController : BaseAdminController
    {
        private readonly ICategoryManager categoryManager;
        private readonly IAdminDrinkService drinks;
        private readonly IDrinkRepository _drinksRepo;
        private readonly ApplicationDbContext _db;

        public DrinksManageController(ICategoryManager categoryManager,
            IAdminDrinkService drinks, IDrinkRepository drinksRepo, ApplicationDbContext db)
        {
            this.categoryManager = categoryManager;
            this._db = db;
            this.drinks = drinks;
            this._drinksRepo = drinksRepo;
        }

        public IActionResult Create()
        {

            var categories = this.categoryManager.GetAllCategories();

            var categoryListItems = categories
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.CategoryId.ToString()

                })
                .ToList();

            return View(new AddDrinkFormModel
            {
                Categories = categoryListItems
            });


        }


        [HttpPost]
        public IActionResult Create(AddDrinkFormModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            this.drinks.Create(
                model.Name,
                model.ShortDescription,
                model.LongDescription,
                model.Price,
                model.ImageUrl,
                model.ImageThumbnail,
                model.Preferred,
                model.InStock,
                model.CategoryId);

            TempData.AddSuccessMessage($"Drink {model.Name} created successfully");

            return RedirectToAction(nameof(HomeController.Index), "Home", new { area = string.Empty });
        }

        public IActionResult Edit(int id)
        {
            var drink = this._drinksRepo.GetDrinkById(id);
            if (drink == null)
            {
                return NotFound();
            }

            var categories = this.categoryManager.GetAllCategories();
            
            var categoryListItems = categories
             .Select(c => new SelectListItem
             {
                 Text = c.Name,
                 Value = c.CategoryId.ToString(),
                 Selected = c.CategoryId == drink.CategoryId


             })
             .ToList();
            ViewBag.Categories = categoryListItems;
            return View(drink);
        }

        [HttpPost]
        public IActionResult Edit(Drink model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(model.DrinkId);

                _db.Drinks.Update(model);
                _db.SaveChanges();
                return RedirectToAction(nameof(HomeController.Index), "Home", new { area = string.Empty });
            }
            else
            {
                return View(model);
            }
        }

        
        public IActionResult Remove(int id)
        {
            
            var drink = this._drinksRepo.GetDrinkById(id);
            if(drink == null)
            {
                return NotFound();
            }

            _db.Drinks.Remove(drink);

            _db.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }


}
