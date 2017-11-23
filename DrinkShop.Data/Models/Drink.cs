namespace DrinkShop.Web.Models
{
    public class Drink
    {
        //Primary key
        public int DrinkId { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string ImageThumbnail { get; set; }

        public bool IsPreferredDrink { get; set; }

        public int InStock { get; set; }

        //Foreign key 
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


        
    }
}
