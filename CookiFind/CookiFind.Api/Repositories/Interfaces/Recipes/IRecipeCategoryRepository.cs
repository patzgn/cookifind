using CookiFind.Api.Models.Domain.Recipes;

namespace CookiFind.Api.Repositories.Interfaces.Recipes;

public interface IRecipeCategoryRepository
{
    Task<List<RecipeCategory>> GetAllAsync();
}
