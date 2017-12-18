using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkShop.Services.Admin
{
    public interface IAdminDrinkService
    {
        void Create(
        string name,
        string shortDescription,
        string longDescription,
        decimal price,
        string imageUrl,
        string imageThumbnail,
        bool isPreferredDrink,
        bool inStock,
        int categoryId);
    }
}

