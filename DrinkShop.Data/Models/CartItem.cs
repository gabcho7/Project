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

        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual Drink Drink { get; set; }
    }
}
