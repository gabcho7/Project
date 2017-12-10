namespace DrinkShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Drink
    {
        //Primary key
        public int DrinkId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [Required]
        [MaxLength(6000)]
        public string LongDescription { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string ImageThumbnail { get; set; }

        [Required]
        public bool IsPreferredDrink { get; set; }
        [Required]
        public int InStock { get; set; }

        //Foreign key 
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
       

        
    }
}
