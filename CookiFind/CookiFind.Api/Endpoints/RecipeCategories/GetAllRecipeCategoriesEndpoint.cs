using CookiFind.Api.Mapping.RecipeCategories;
using CookiFind.Application.Services.Interfaces.Recipes;
using CookiFind.Contracts.Responses.RecipeCategories;

namespace CookiFind.Api.Endpoints.RecipeCategories;

public static class GetAllRecipeCategoriesEndpoint
{
    public const string Name = "GetAllRecipeCategories";

    public static IEndpointRouteBuilder MapGetAllRecipeCategories(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.RecipeCategories.GetAll,
                async (IRecipeCategoryService recipeCategoryService, CancellationToken cancellationToken) =>
                {
                    var recipeCategories = await recipeCategoryService.GetAllAsync(cancellationToken);

                    var response = recipeCategories.MapToResponse();
                    return TypedResults.Ok(response);
                })
            .WithName(Name)
            .Produces<IEnumerable<RecipeCategoryResponse>>(StatusCodes.Status200OK)
            .AllowAnonymous();

        return app;
    }
}
