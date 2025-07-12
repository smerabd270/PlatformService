namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation( IApplicationBuilder app)
        {
            using (var serviceScoped = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScoped.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any()) { }
            else
            {
                Console.WriteLine("------> We alreadyhvae data");
            }
        }
    }
}
