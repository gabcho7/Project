using DrinkShop.Data;
using DrinkShop.Data.Models;
using DrinkShop.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.Web.Services
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext _appDbContext;
        public CategoryRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> Categories => _appDbContext.Categories;
    }


}

