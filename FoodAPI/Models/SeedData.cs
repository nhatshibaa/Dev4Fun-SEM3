using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FoodAPI.Data;
using System;
using System.Linq;

namespace FoodAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FoodAPIContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FoodAPIContext>>()))
            {
                // Look for any movies.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Id = 1,
                        Name = "Banh Gato",
                        Image= "Romantic Comedy",
                        Vote = "1",
                        Description = "so delicous",
                        Price = 99,
                        Quantity = 99,
                        Status = 1,
                        Timestamp = DateTime.Now,
                        

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
