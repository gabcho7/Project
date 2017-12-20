using DrinkShop.Services.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.Web.Infrastructure.Extentions
{
    public static class SessionExtentions
    {
        private const string SessionCartIdentifier = "ShoppingCartId";

        public static string GetShoppingCartId(this ISession session)
        {

            var shoppingCartId = session.GetString(SessionCartIdentifier);

            if (shoppingCartId == null)
            {
                shoppingCartId = Guid.NewGuid().ToString();
                session.SetString(SessionCartIdentifier, shoppingCartId);
            }

            return shoppingCartId;
        }
    }

}