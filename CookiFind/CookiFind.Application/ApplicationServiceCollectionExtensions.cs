using CookiFind.Application.Database;
using CookiFind.Application.Repositories.Interfaces.Recipes;
using CookiFind.Application.Repositories.Recipes;
using CookiFind.Application.Services.Interfaces.Recipes;
using CookiFind.Application.Services.Interfaces.Scrapers;
using CookiFind.Application.Services.Recipes;
using CookiFind.Application.Services.Scrapers;
using Microsoft.Extensions.DependencyInjection;

namespace CookiFind.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IRecipeRepository, RecipeRepository>();
        services.AddSingleton<IRecipeCategoryRepository, RecipeCategoryRepository>();

        services.AddSingleton<IRecipeCategoryService, RecipeCategoryService>();

        services.AddSingleton<IRecipeScraper, RecipeScraper>();
        services.AddSingleton<IScraper, CookidooScraper>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IDbConnectionFactory>(_ => new NpgsqlConnectionFactory(connectionString));
        services.AddSingleton<DbInitializer>();

        return services;
    }
}
