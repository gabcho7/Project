using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkShop.Web.Areas.Admin.Models.Drinks
{
    public class AddDrinkFormModel
    {
        [Required]
        [MinLength(3)]
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
        public bool Preferred { get; set; }

        [Required]
        public bool InStock { get; set; }

        [Required]
        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}
