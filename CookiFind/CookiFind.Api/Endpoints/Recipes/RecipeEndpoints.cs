using CookiFind.Api.Scrapers.Interfaces;

namespace CookiFind.Api.Endpoints.Recipes;

public static class RecipeEndpoints
{
    public static IEndpointRouteBuilder MapRecipeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/recipes/scrape", async (IScraper scraper) =>
        {
            await scraper.ScrapeAndSaveRecipesAsync();
        });
        
        return app;
    }
}
