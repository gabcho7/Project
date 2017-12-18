namespace DrinkShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int DrinkId { get; set; }

        public Drink Drink { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal DrinkPrice { get; set; }

       
    }
}
