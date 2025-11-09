using CookiFind.Application.Models.Recipes;
using CookiFind.Contracts.Responses.RecipeCategories;

namespace CookiFind.Api.Mapping.RecipeCategories;

public static class RecipeCategoryMapping
{
    public static IEnumerable<RecipeCategoryResponse> MapToResponse(this IEnumerable<RecipeCategory> recipeCategories)
    {
        return recipeCategories.Select(x => new RecipeCategoryResponse
        {
            Name = x.Name,
        });
    }
}
