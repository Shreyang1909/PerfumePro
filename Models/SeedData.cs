using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PerfumePro.Data;
using System;
using System.Linq;

namespace PerfumePro.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PerfumeProContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PerfumeProContext>>()))
            {
                // Look for any movies.
                if (context.Perfume.Any())
                {
                    return;   // DB has been seeded
                }

                context.Perfume.AddRange(
                    new Perfume
                    {
                        Name = "Eternal Blossom",
                        Brand = "Blossom Scents",
                        Fragrance = "Floral",
                        Gender = "Female",
                        Country = "USA",
                        Price = 50

                    },
                new Perfume
                {
                    Name = "Citrus Zest",
                    Brand = "Citrus Creations",
                    Fragrance = "Citrus",
                    Gender = "Unisex",
                    Country = "France",
                    Price = 6,
                    Rating= 2
                },
                new Perfume
                {
                    Name = "Woodsy Charm",
                    Brand = "Woodsy Wonders",
                    Fragrance = "Woody",
                    Gender = "Male",
                    Country = "Italy",
                    Price = 45,
                    Rating = 3
                },
                new Perfume
                {
                    Name = "Sweet Serenity",
                    Brand = "Sweet Moments",
                    Fragrance = "Sweet",
                    Gender = "Female",
                    Country = "Spain",
                    Price = 55,
                    Rating = 2.5

                },
                new Perfume
                {
                    Name = "Fresh Breeze",
                    Brand = "Fresh Air",
                    Fragrance = "Fresh",
                    Gender = "Unisex",
                    Country = "UK",
                    Price = 70,
                    Rating = 1.5
                },
                new Perfume
                {
                    Name = "Spice Fusion",
                    Brand = "Spice Sensations",
                    Fragrance = "Spicy",
                    Gender = "Male",
                    Country = "Germany",
                    Price = 60,
                    Rating = 3.5

                },
                new Perfume
                {
                    Name = "Fruitful Delight",
                    Brand = "Fruitful Bliss",
                    Fragrance = "Fruity",
                    Gender = "Female",
                    Country = "Australia",
                    Price = 40,
                    Rating = 4.5
                },
                new Perfume
                {
                    Name = "Aquatic Breeze",
                    Brand = "Aqua Waves",
                    Fragrance = "Aquatic",
                    Gender = "Unisex",
                    Country = "Canada",
                    Price = 75,
                    Rating = 1.5
                },
                new Perfume
                {
                    Name = "Mystic Oriental",
                    Brand = "Oriental Elegance",
                    Fragrance = "Oriental",
                    Gender = "Male",
                    Country = "Japan",
                    Price = 65,
                    Rating = 5
                },
                new Perfume
                {
                    Name = "Vanilla Dream",
                    Brand = "Vanilla Bliss",
                    Fragrance = "Vanilla",
                    Gender = "Female",
                    Country = "Brazil",
                    Price = 50,
                    Rating = 1
                }
            );
            context.SaveChanges();
            }
        }
    }
}