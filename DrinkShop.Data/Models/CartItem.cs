using System.ComponentModel.DataAnnotations;

namespace DrinkShop.Data.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ShoppingCartId { get; set; }

        public int DrinkId { get; set; }

        public ShoppingCart ShoppingCart { get; set;}
        public Drink Drink { get; set; }
    }
}
