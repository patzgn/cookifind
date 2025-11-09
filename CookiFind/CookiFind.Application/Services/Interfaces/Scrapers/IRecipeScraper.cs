using CookiFind.Application.Models.Recipes;

namespace CookiFind.Application.Services.Interfaces.Scrapers;

public interface IRecipeScraper
{
    Task<IEnumerable<string>> GetRecipesIdsAsync(string categoryId);
    Task<Recipe?> GetRecipeAsync(string recipeId, Guid categoryId);
}
