using CookiFind.Application.Models.Recipes;

namespace CookiFind.Application.Services.Interfaces.Recipes;

public interface IRecipeCategoryService
{
    Task<IEnumerable<RecipeCategory>> GetAllAsync(CancellationToken cancellationToken);
}
