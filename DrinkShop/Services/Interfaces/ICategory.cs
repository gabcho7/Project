using DrinkShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.Web.Services.Interfaces
{
   public interface ICategory
    {
        IEnumerable<Category> Categories { get; }
    }
}
