using DrinkShop.Data.Models;

namespace DrinkShop.Services
{
    public interface IOrderManager
    {
        void CheckoutCart(string address, string firstName, string lastName, string city, string country, string phoneNumber, string email);
    }
}
