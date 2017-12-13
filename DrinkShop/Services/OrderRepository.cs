using DrinkShop.Web.Services.Interfaces;
using DrinkShop.Data.Models;
using DrinkShop.Data;

namespace DrinkShop.Web.Services
{
    public class OrderRepository : IOrder
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(ApplicationDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.CartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Count = shoppingCartItem.Count,
                    DrinkId = shoppingCartItem.Drink.DrinkId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Drink.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
