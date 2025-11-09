using CookiFind.Application.Models.Recipes;
using CookiFind.Application.Repositories.Interfaces.Recipes;
using CookiFind.Application.Services.Interfaces.Recipes;

namespace CookiFind.Application.Services.Recipes;

public class RecipeCategoryService(IRecipeCategoryRepository repository) : IRecipeCategoryService
{
    public async Task<IEnumerable<RecipeCategory>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}
