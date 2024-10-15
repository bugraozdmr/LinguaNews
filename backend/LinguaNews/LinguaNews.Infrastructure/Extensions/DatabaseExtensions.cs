using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LinguaNews.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    // carefull -- nasıl oldu bilmiyorum application Dependency Injection eklerken WebApplicationu tanımaya başladı
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.MigrateAsync().GetAwaiter().GetResult();
        
        await SeedAsync(context);
    }
    
    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedCategoriesAsync(context);
        await SeedNewsAsync(context);
    }
    
    private static async Task SeedCategoriesAsync(ApplicationDbContext context)
    {
        // first check then insert
        if (!await context.Categories.AnyAsync())
        {
            await context.Categories.AddRangeAsync(InitialData.Categories);
            await context.SaveChangesAsync();
        }
    }
    
    private static async Task SeedNewsAsync(ApplicationDbContext context)
    {
        if (!await context.News.AnyAsync())
        {
            await context.News.AddRangeAsync(InitialData.Newss);
            await context.SaveChangesAsync();
        }
    }
}