using CookiFind.Application.Database;
using CookiFind.Application.Repositories.Interfaces.Recipes;
using CookiFind.Application.Repositories.Recipes;
using CookiFind.Application.Services.Interfaces.Recipes;
using CookiFind.Application.Services.Interfaces.Scrapers;
using CookiFind.Application.Services.Recipes;
using CookiFind.Application.Services.Scrapers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CookiFind.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRecipeRepository, RecipeRepository>();
        services.AddScoped<IRecipeCategoryRepository, RecipeCategoryRepository>();

        services.AddScoped<IRecipeCategoryService, RecipeCategoryService>();

        services.AddScoped<IRecipeScraper, RecipeScraper>();
        services.AddScoped<IScraper, CookidooScraper>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CookiFindDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}
