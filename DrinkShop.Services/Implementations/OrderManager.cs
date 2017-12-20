using DrinkShop.Services;
using DrinkShop.Data.Models;
using DrinkShop.Data;
using DrinkShop.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;

namespace DrinkShop.Web.Services
{
    public class OrderManager : IOrderManager
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly IShoppingCartManager _shoppingCartManager;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public OrderManager(
            ApplicationDbContext appDbContext,
            IShoppingCartManager shoppingCartManager,
            UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _shoppingCartManager = shoppingCartManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public void CheckoutCart(string address, string firstName, string lastName, string city, string country, string phoneNumber, string email)
        {
            
            var order = CreateOrder(address, firstName, lastName, city, country, phoneNumber, email);
            
            order = TransformCartToOrder(order);
           
            string userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            User user = _appDbContext.Users.First(u => u.Id == userId);
            order.User = user;
            _shoppingCartManager.ClearCart();
            _appDbContext.SaveChanges();

        }

        private Order CreateOrder(string address = null, string firstName = null, string lastName = null, string city = null, string country = null, string phoneNumber = null, string email = null)
        {
            var order = new Order();
           
            order.Address = address;
            order.City = city;
            order.FirstName = firstName;
            order.LastName = lastName;
            order.Country = country;
            order.Email = email;
            order.PhoneNumber = phoneNumber;
        
            _appDbContext.Add(order);
            return order;
        }

        
        private OrderItem CreateOrderItem()
        {
            var orderItem = new OrderItem();
            
            return orderItem;
        }

        

    private Order TransformCartToOrder(Order order)
        {
            var cart = _shoppingCartManager.GetCart();

            foreach (var item in cart.Items)
            {
                var orderItem = CreateOrderItem();
                orderItem.Order = order;
                orderItem.OrderId = order.OrderId;
                orderItem.Quantity = item.Quantity;
                orderItem.DrinkPrice = item.Drink.Price * item.Quantity;
                orderItem.DrinkId = item.Drink.DrinkId;
                order.OrderTotal += orderItem.DrinkPrice;
                _appDbContext.Add(orderItem);
            }

           
            return order;
        }
    }
}
