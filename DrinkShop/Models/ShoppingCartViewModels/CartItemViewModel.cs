
namespace DrinkShop.Web.Models.ShoppingCartViewModels
{
    public class CartItemViewModel
    {
        public int DrinkId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
