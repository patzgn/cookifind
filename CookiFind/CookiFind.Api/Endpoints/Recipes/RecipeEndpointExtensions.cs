namespace CookiFind.Api.Endpoints.Recipes;

public static class RecipeEndpointExtensions
{
    public static IEndpointRouteBuilder MapRecipeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapScrapeRecipes();

        return app;
    }
}
