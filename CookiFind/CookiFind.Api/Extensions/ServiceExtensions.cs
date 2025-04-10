using CookiFind.Api.Data;
using CookiFind.Api.Repositories.Interfaces.Recipes;
using CookiFind.Api.Repositories.Recipes;
using CookiFind.Api.Scrapers;
using CookiFind.Api.Scrapers.Interfaces;
using CookiFind.Api.Services.Interfaces.Recipes;
using CookiFind.Api.Services.Recipes;
using Microsoft.EntityFrameworkCore;

namespace CookiFind.Api.Extensions;

public static class ServiceExtensions
{
    public static void AddCookiFindDbContext(this IHostApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddDbContext<CookiFindDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
    }

    public static void AddCookiFindRepositories(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
        builder.Services.AddScoped<IRecipeCategoryRepository, RecipeCategoryRepository>();
    }

    public static void AddCookiFindServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRecipeCategoryService, RecipeCategoryService>();
    }

    public static void AddCookidooScraper(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IScraper, CookidooScraper>();
        builder.Services.AddScoped<IRecipeScraper, RecipeScraper>();
    }
}
