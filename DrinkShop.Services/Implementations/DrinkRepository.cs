using DrinkShop.Data;
using DrinkShop.Data.Models;
using DrinkShop.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DrinkShop.Web.Services
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public DrinkRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Drink> Drinks => appDbContext.Drinks.Include(c => c.Category);

        public IEnumerable<Drink> PreferredDrinks => appDbContext.Drinks.Where(p => p.IsPreferredDrink).Include(c => c.Category);

        public Drink GetDrinkById(int drinkId) => appDbContext.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);


        //    public void Seed()
        //    {
        //        ApplicationDbContext context = appDbContext;

        //        if (!context.Categories.Any())
        //        {
        //            context.Categories.AddRange(Categories.Select(c => c.Value));
        //        }

        //        if (!context.Drinks.Any())
        //        {
        //            context.AddRange
        //            (
        //                new Drink
        //                {
        //                    Name = "Beer",
        //                    Price = 8.00M,
        //                    ShortDescription = "The most widely consumed alcohol",
        //                    LongDescription = "Beer is the world's oldest[1][2][3] and most widely consumed[4] alcoholic drink; it is the third most popular drink overall, after water and tea.[5] The production of beer is called brewing, which involves the fermentation of starches, mainly derived from cereal grains—most commonly malted barley, although wheat, maize (corn), and rice are widely used.[6] Most beer is flavoured with hops, which add bitterness and act as a natural preservative, though other flavourings such as herbs or fruit may occasionally be included. The fermentation process causes a natural carbonation effect, although this is often removed during processing, and replaced with forced carbonation.[7] Some of humanity's earliest known writings refer to the production and distribution of beer: the Code of Hammurabi included laws regulating beer and beer parlours.",
        //                    Category = Categories["Alcoholic"],
        //                    ImageUrl = "https://i.pinimg.com/564x/46/e2/80/46e2805f287f2e88e3dca5776b567550.jpg",
        //                    InStock = true,
        //                    IsPreferredDrink = true,
        //                    ImageThumbnail = "https://i.pinimg.com/564x/46/e2/80/46e2805f287f2e88e3dca5776b567550.jpg"
        //                },

        //                new Drink
        //                {
        //                    Name = "Tequila ",
        //                    Price = 45.00M,
        //                    ShortDescription = "Distilled beverage made from cactus.",
        //                    LongDescription = "Tequila (Spanish About this sound [teˈkila] (help·info)) is a regionally specific name for a distilled beverage made from the blue agave plant, primarily in the area surrounding the city of Tequila, 65 km (40 mi) northwest of Guadalajara, and in the highlands (Los Altos) of the central western Mexican state of Jalisco. Although tequila is similar to mezcal, modern tequila differs somewhat in the method of its production, in the use of only blue agave plants, as well as in its regional specificity. Tequila is commonly served neat in Mexico and as a shot with salt and lime across the rest of the world.The red volcanic soil in the surrounding region is particularly well suited to the growing of the blue agave, and more than 300 million of the plants are harvested there each year.[1] Agave tequila grows differently depending on the region. Blue agaves grown in the highlands Los Altos region are larger in size and sweeter in aroma and taste. Agaves harvested in the lowlands, on the other hand, have a more herbaceous fragrance and flavor.",
        //                    Category = Categories["Alcoholic"],
        //                    ImageUrl = "https://i.pinimg.com/564x/5f/a7/54/5fa7540295e6194197c5456c58c6362a.jpg",
        //                    InStock = true,
        //                    IsPreferredDrink = false,
        //                    ImageThumbnail = "https://i.pinimg.com/564x/5f/a7/54/5fa7540295e6194197c5456c58c6362a.jpg"
        //                },
        //                new Drink
        //                {
        //                    Name = "Wine ",
        //                    Price = 38.00M,
        //                    ShortDescription = "A very elegant alcoholic drink",
        //                    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
        //                    Category = Categories["Alcoholic"],
        //                    ImageUrl = "https://i.pinimg.com/564x/71/27/83/7127833de3bc93fa2a2d7c939090cee6.jpg",
        //                    InStock = true,
        //                    IsPreferredDrink = false,
        //                    ImageThumbnail = "https://i.pinimg.com/564x/71/27/83/7127833de3bc93fa2a2d7c939090cee6.jpg"
        //                },

        //                new Drink
        //                {
        //                    Name = "Whiskey",
        //                    Price = 15.95M,
        //                    ShortDescription = "The best alcohol",
        //                    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
        //                    Category = Categories["Alcoholic"],
        //                    ImageUrl = "https://i.pinimg.com/564x/98/42/2a/98422a6eae606c9a5abf88c22340146e.jpg",
        //                    InStock = false,
        //                    IsPreferredDrink = false,
        //                    ImageThumbnail = "https://i.pinimg.com/564x/98/42/2a/98422a6eae606c9a5abf88c22340146e.jpg"
        //                },

        //                new Drink
        //                {
        //                    Name = "Champagne",
        //                    Price = 69.00M,
        //                    ShortDescription = "That is how sparkling wine can be called",
        //                    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
        //                    Category = Categories["Alcoholic"],
        //                    ImageUrl = "https://i.pinimg.com/564x/dc/7f/8a/dc7f8aa8034d49554073df27b3afa65f.jpg",
        //                    InStock = true,
        //                    IsPreferredDrink = false,
        //                    ImageThumbnail = "https://i.pinimg.com/564x/dc/7f/8a/dc7f8aa8034d49554073df27b3afa65f.jpg"
        //                },
        //                new Drink
        //                {
        //                    Name = "Piña colada ",
        //                    Price = 15.95M,
        //                    ShortDescription = "A sweet cocktail made with rum.",
        //                    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
        //                    Category = Categories["Alcoholic"],
        //                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41Jce3h4DyL.jpg",
        //                    InStock = true,
        //                    IsPreferredDrink = false,
        //                    ImageThumbnail = "https://images-na.ssl-images-amazon.com/images/I/41Jce3h4DyL.jpg"
        //                },

        //                new Drink
        //                {
        //                    Name = "Vodka",
        //                    Price = 56.00M,
        //                    ShortDescription = "A distilled beverage with water and ethanol.",
        //                    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
        //                    Category = Categories["Alcoholic"],
        //                    ImageUrl = "http://www.casadevinos.com.au/assets/full/SKU4625.jpg",
        //                    InStock = true,
        //                    IsPreferredDrink = false,
        //                    ImageThumbnail = "http://www.casadevinos.com.au/assets/full/SKU4625.jpg"
        //                },

        //                new Drink
        //                {
        //                    Name = "Tea ",
        //                    Price = 14.00M,
        //                    ShortDescription = "Tea with unique taste.",
        //                    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
        //                    Category = Categories["Non-alcoholic"],
        //                    ImageUrl = "http://www.newenglishteas.com/uploads/2/5/6/6/25665453/w500-mt56-english-fine-tea-1215_orig.jpg",
        //                    InStock = true,
        //                    IsPreferredDrink = true,
        //                    ImageThumbnail = "http://www.newenglishteas.com/uploads/2/5/6/6/25665453/w500-mt56-english-fine-tea-1215_orig.jpg"
        //                },
        //                new Drink
        //                {
        //                    Name = "Water ",
        //                    Price = 7.00M,
        //                    ShortDescription = "Water with collagen",
        //                    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
        //                    Category = Categories["Non-alcoholic"],
        //                    ImageUrl = "http://www.packagingdigest.com/sites/default/files/styles/featured_image_750x422/public/299856-Danone_AQUA_Reflections.jpg?itok=fJZxb4VA",
        //                    InStock = true,
        //                    IsPreferredDrink = false,
        //                    ImageThumbnail = "http://www.packagingdigest.com/sites/default/files/styles/featured_image_750x422/public/299856-Danone_AQUA_Reflections.jpg?itok=fJZxb4VA"
        //                },
        //                new Drink
        //                {
        //                    Name = "Coffee ",
        //                    Price = 5.00M,
        //                    ShortDescription = "A beverage prepared from coffee beans",
        //                    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
        //                    Category = Categories["Non-alcoholic"],
        //                    ImageUrl = "https://cdn.isagenix.com/fos/5/9/4/%7B59449C7F-DE73-49EF-A200-8D1A7D819273%7D.png",
        //                    InStock = true,
        //                    IsPreferredDrink = true,
        //                    ImageThumbnail = "https://cdn.isagenix.com/fos/5/9/4/%7B59449C7F-DE73-49EF-A200-8D1A7D819273%7D.png"
        //                },
        //                new Drink
        //                {
        //                    Name = "Kvass",
        //                    Price = 10.00M,
        //                    ShortDescription = "A very refreshing Russian beverage",
        //                    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
        //                    Category = Categories["Non-alcoholic"],
        //                    ImageUrl = "https://i.pinimg.com/564x/f3/6b/11/f36b11fe9c5f0b98203efb22000d66db.jpg",
        //                    InStock = true,
        //                    IsPreferredDrink = false,
        //                    ImageThumbnail = "https://i.pinimg.com/564x/f3/6b/11/f36b11fe9c5f0b98203efb22000d66db.jpg"
        //                },
        //                new Drink
        //                {
        //                    Name = "Juice ",
        //                    Price = 8.00M,
        //                    ShortDescription = "Naturally contained in fruit or vegetable tissue.",
        //                    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
        //                    Category = Categories["Non-alcoholic"],
        //                    ImageUrl = "https://i.pinimg.com/564x/d9/bf/a0/d9bfa07fc51383a27112f478a8dd6f02.jpg",
        //                    InStock = true,
        //                    IsPreferredDrink = false,
        //                    ImageThumbnail = "https://i.pinimg.com/564x/d9/bf/a0/d9bfa07fc51383a27112f478a8dd6f02.jpg"
        //                }
        //            );
        //        }

        //        context.SaveChanges();
        //    }

        //    private static Dictionary<string, Category> categories;
        //    public static Dictionary<string, Category> Categories
        //    {
        //        get
        //        {
        //            if (categories == null)
        //            {
        //                var genresList = new Category[]
        //                {
        //                    new Category { Name = "Alcoholic", Description="Alcoholic drinks" },
        //                    new Category { Name = "Non-alcoholic", Description="Non-alcoholic drinks" }
        //                };

        //                categories = new Dictionary<string, Category>();

        //                foreach (Category genre in genresList)
        //                {
        //                    categories.Add(genre.Name, genre);
        //                }
        //            }

        //            return categories;
        //        }
        //    }
        //}



    }
}

