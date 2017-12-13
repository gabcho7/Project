namespace DrinkShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int DrinkId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Drink Drink { get; set; }
    }
}
