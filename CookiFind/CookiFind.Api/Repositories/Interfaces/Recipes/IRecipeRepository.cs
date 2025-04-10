using CookiFind.Api.Models.Domain.Recipes;

namespace CookiFind.Api.Repositories.Interfaces.Recipes;

public interface IRecipeRepository
{
    Task AddAsync(Recipe recipe);

    Task AddAsync(IEnumerable<Recipe> recipes);

    Task<IEnumerable<string>> GetCookidooIdsAsync(Guid categoryId);
}
