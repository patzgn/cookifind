using CookiFind.Api.Endpoints.RecipeCategories;
using CookiFind.Api.Endpoints.Recipes;

namespace CookiFind.Api.Endpoints;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapRecipeCategoryEndpoints();
        app.MapRecipeEndpoints();

        return app;
    }
}
