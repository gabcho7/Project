using DrinkShop.Data.Controllers;
using DrinkShop.Services.Admin;
using DrinkShop.Services.Contracts;
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

        public DrinksManageController(ICategoryManager categoryManager,
            IAdminDrinkService drinks)
        {
            this.categoryManager = categoryManager;
            this.drinks = drinks;
        }

        public IActionResult Create()
        {
            //return View(new CreateDrinkViewModel
            //{
               // Categories = this.categoryManager.GetAllCategories()

               //});

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
                model.IsPreferredDrink,
                model.InStock,
                model.CategoryId);

            TempData.AddSuccessMessage($"Drink {model.Name} created successfully");

            return RedirectToAction(nameof(HomeController.Index), "Home", new { area = string.Empty});
        }
    }

   
    //TO DO 
    //public async Task<IActionResult> RemoveAlbum(int id)
    //{
    //    var album = await DbContext.Albums.Where(a => a.AlbumId == id).FirstOrDefaultAsync();
    //    if (album == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(album);
    //}
}
