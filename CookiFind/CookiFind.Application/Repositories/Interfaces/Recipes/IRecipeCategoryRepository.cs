using CookiFind.Application.Models.Recipes;

namespace CookiFind.Application.Repositories.Interfaces.Recipes;

public interface IRecipeCategoryRepository
{
    Task<IEnumerable<RecipeCategory>> GetAllAsync(CancellationToken cancellationToken);
    Task<RecipeCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
