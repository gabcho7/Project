using DrinkShop.Data.Models;

namespace DrinkShop.Web.Services.Interfaces
{
    public interface IOrder
    {
        void CreateOrder(Order order);
    }
}
