using CookiFind.Application.Models.Recipes;

namespace CookiFind.Application.Repositories.Interfaces.Recipes;

public interface IRecipeRepository
{
    Task<bool> CreateAsync(Recipe recipe, CancellationToken cancellationToken);

    Task<bool> CreateAsync(IEnumerable<Recipe> recipes, CancellationToken cancellationToken);

    Task<IEnumerable<string>> GetCookidooIdsAsync(Guid categoryId, CancellationToken cancellationToken);
}
