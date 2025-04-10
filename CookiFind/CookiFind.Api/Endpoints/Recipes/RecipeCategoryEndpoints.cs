using CookiFind.Api.Services.Interfaces.Recipes;

namespace CookiFind.Api.Endpoints.Recipes;

public static class RecipeCategoryEndpoints
{
    public static IEndpointRouteBuilder MapRecipeCategoriesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/recipe-categories", async (IRecipeCategoryService service) => await service.GetAllAsync());

        return app;
    }
}
