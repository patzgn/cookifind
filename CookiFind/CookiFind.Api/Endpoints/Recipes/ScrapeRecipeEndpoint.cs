using CookiFind.Application.Services.Interfaces.Scrapers;
using Microsoft.AspNetCore.Mvc;

namespace CookiFind.Api.Endpoints.Recipes;

public static class ScrapeRecipeEndpoint
{
    public const string Name = "ScrapeRecipes";

    public static IEndpointRouteBuilder MapScrapeRecipes(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Recipes.Scrape,
                async ([FromQuery(Name = "category")] Guid? recipeCategoryId, IScraper scraper,
                    CancellationToken cancellationToken) =>
                {
                    bool result;

                    if (recipeCategoryId.HasValue)
                    {
                        result = await scraper.ScrapeAndSaveRecipesAsync(recipeCategoryId.Value, cancellationToken);
                    }
                    else
                    {
                        result = await scraper.ScrapeAndSaveRecipesAsync(cancellationToken);
                    }

                    return result
                        ? Results.Ok()
                        : Results.InternalServerError();
                })
            .WithName(Name)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

        return app;
    }
}
