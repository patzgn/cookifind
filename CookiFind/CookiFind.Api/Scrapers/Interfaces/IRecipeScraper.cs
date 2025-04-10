using CookiFind.Api.Models.Domain.Recipes;

namespace CookiFind.Api.Scrapers.Interfaces;

public interface IRecipeScraper
{
    Task<IEnumerable<string>> GetRecipesIdsAsync(string categoryId);
    Task<Recipe?> GetRecipeAsync(string recipeId, Guid categoryId);
}
