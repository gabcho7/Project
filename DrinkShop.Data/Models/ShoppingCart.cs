namespace DrinkShop.Data.Models
{ 
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

   public class ShoppingCart
    {
        
        public string ShoppingCartId { get; set; }

        public List<CartItem> CartItems { get; set; }

        private readonly ApplicationDbContext _appDbContext;
        private ShoppingCart(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }


        public void AddToCart(Drink drink, int amount)
        {
            var shoppingCartItem =
                    _appDbContext.CartItems.SingleOrDefault(
                        s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new CartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Drink = drink,
                    Count = 1
                };

                _appDbContext.CartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Count++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Drink drink)
        {
            var shoppingCartItem =
                    _appDbContext.CartItems.SingleOrDefault(
                        s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Count > 1)
                {
                    shoppingCartItem.Count--;
                    localAmount = shoppingCartItem.Count;
                }
                else
                {
                    _appDbContext.CartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }

        public List<CartItem> GetShoppingCartItems()
        {
            return CartItems ??
                   (CartItems =
                       _appDbContext.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Drink)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .CartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.CartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Drink.Price * c.Count).Sum();
            return total;
        }


        //OR


        //private readonly ApplicationDbContext _dbContext;
        //private readonly string _shoppingCartId;

        //private ShoppingCart(ApplicationDbContext dbContext, string id)
        //{
        //    _dbContext = dbContext;
        //    _shoppingCartId = id;
        //}

        //public static ShoppingCart GetCart(ApplicationDbContext db, HttpContext context)
        //    => GetCart(db, GetCartId(context));

        //public static ShoppingCart GetCart(ApplicationDbContext db, string cartId)
        //    => new ShoppingCart(db, cartId);


        //public async Task AddToCart(Drink drink)
        //{
        //    // Get the matching cart and drink instances
        //    var cartItem = await _dbContext.CartItems.SingleOrDefaultAsync(
        //        c => c.ShoppingCartId == _shoppingCartId
        //        && c.DrinkId == drink.DrinkId);

        //    if (cartItem == null)
        //    {
        //        // Create a new cart item if no cart item exists
        //        cartItem = new CartItem
        //        {
        //            DrinkId = drink.DrinkId,
        //            ShoppingCartId = _shoppingCartId,
        //            Count = 1,

        //        };

        //        _dbContext.CartItems.Add(cartItem);
        //    }
        //    else
        //    {
        //        // If the item does exist in the cart, then add one to the quantity
        //        cartItem.Count++;
        //    }
        //}

        //public int RemoveFromCart(int id)
        //{
        //    // Get the cart
        //    var cartItem = _dbContext.CartItems.SingleOrDefault(
        //        cart => cart.ShoppingCartId == _shoppingCartId
        //        && cart.CartItemId == id);

        //    int itemCount = 0;

        //    if (cartItem != null)
        //    {
        //        if (cartItem.Count > 1)
        //        {
        //            cartItem.Count--;
        //            itemCount = cartItem.Count;
        //        }
        //        else
        //        {
        //            _dbContext.CartItems.Remove(cartItem);
        //        }
        //    }

        //    return itemCount;
        //}

        //public async Task EmptyCart()
        //{
        //    var cartItems = await _dbContext
        //        .CartItems
        //        .Where(cart => cart.ShoppingCartId == _shoppingCartId)
        //        .ToArrayAsync();

        //    _dbContext.CartItems.RemoveRange(cartItems);
        //}

        //public Task<List<CartItem>> GetCartItems()
        //{
        //    return _dbContext
        //        .CartItems
        //        .Where(cart => cart.ShoppingCartId == _shoppingCartId)
        //        .Include(c => c.Drink)
        //        .ToListAsync();
        //}

        //public Task<List<string>> GetCartDrinkNames()
        //{
        //    return _dbContext
        //        .CartItems
        //        .Where(cart => cart.ShoppingCartId == _shoppingCartId)
        //        .Select(c => c.Drink.Name)
        //        .OrderBy(n => n)
        //        .ToListAsync();
        //}

        //public Task<int> GetCount()
        //{
        //    // Get the count of each item in the cart and sum them up
        //    return _dbContext
        //        .CartItems
        //        .Where(c => c.ShoppingCartId == _shoppingCartId)
        //        .Select(c => c.Count)
        //        .SumAsync();
        //}

        //public Task<decimal> GetTotal()
        //{
        //    // Multiply drinks price by count  
        //    // the current price for each of those drinks in the cart
        //    // sum all drink prices to get the cart total

        //    return _dbContext
        //        .CartItems
        //        .Where(c => c.ShoppingCartId == _shoppingCartId)
        //        .Select(c => c.Drink.Price * c.Count)
        //        .SumAsync();
        //}

        //public async Task<int> CreateOrder(Order order)
        //{
        //    decimal orderTotal = 0;

        //    var cartItems = await GetCartItems();

        //    // Iterate over the items in the cart, adding the order details for each
        //    foreach (var item in cartItems)
        //    {
        //        //var album = _db.Albums.Find(item.AlbumId);
        //        var drink = await _dbContext.Drinks.SingleAsync(a => a.DrinkId == item.DrinkId);

        //        var orderDetail = new OrderDetail
        //        {
        //            DrinkId = item.DrinkId,
        //            OrderId = order.OrderId,
        //            Price = drink.Price,
        //            Quantity = item.Count,
        //        };

        //        // Set the order total of the shopping cart
        //        orderTotal += (item.Count * drink.Price);

        //        _dbContext.OrderDetails.Add(orderDetail);
        //    }

        //    // Set the order's total to the orderTotal count
        //    order.OrderTotal = orderTotal;

        //    // Empty the shopping cart
        //    await EmptyCart();

        //    // Return the OrderId as the confirmation number
        //    return order.OrderId;
        //}

        //// Using HttpContextBase to allow access to sessions.
        //private static string GetCartId(HttpContext context)
        //{
        //    var cartId = context.Session.GetString("Session");

        //    if (cartId == null)
        //    {
        //        //A GUID to hold the cartId. 
        //        cartId = Guid.NewGuid().ToString();

        //        // Send cart Id as a cookie to the client.
        //        context.Session.SetString("Session", cartId);
        //    }

        //    return cartId;
        //}


    }
}

