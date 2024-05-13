namespace PlatformService;

public static class PrepDb
{
    public static void SeedData(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedDataHelper(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedDataHelper(AppDbContext dbContext)
    {
        if (dbContext.Platforms.Any())
        {
            Console.WriteLine("--> Data already exists");
        }
        else
        {
            Console.WriteLine("--> Seeding data..");
            dbContext.Platforms.AddRange(
                    new Platform { Name = "Dotnet Core", Provider = "Microsoft", Cost = 1000 },
                    new Platform { Name = "Docker", Provider = "DockerHub", Cost = 2300 },
                    new Platform { Name = "Kubernettes", Provider = "Google", Cost = 500 }
            );
            dbContext.SaveChanges();
        }
    }
}
