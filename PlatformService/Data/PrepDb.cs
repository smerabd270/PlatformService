using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScoped = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScoped.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("----> Seed data");
                context.Platforms.AddRange(
                    new Platform { Name = "Dot Net", Publisher = "microsoft", Cost = "free" },
                    new Platform { Name = "Sql server Express", Publisher = "microsoft", Cost = "free" },
                    new Platform { Name = "kubernetes", Publisher = "cloud native computing fundation", Cost = "free" }
                    );
                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("------> We alreadyhvae data");
            }
        }
    }
}
