using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrinkShop.Data.Models
{
    public class Category
    {
       public int CategoryId {get;set;}
    
       [Required]
       public string Name { get; set; }

       public string Description { get; set; }

       public List<Drink> Drinks { get; set; }

    }
}
