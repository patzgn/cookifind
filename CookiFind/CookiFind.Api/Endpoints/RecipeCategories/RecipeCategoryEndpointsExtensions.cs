namespace CookiFind.Api.Endpoints.RecipeCategories;

public static class RecipeCategoryEndpointsExtensions
{
    public static IEndpointRouteBuilder MapRecipeCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGetAllRecipeCategories();

        return app;
    }
}
