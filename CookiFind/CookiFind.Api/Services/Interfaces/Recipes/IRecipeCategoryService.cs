using CookiFind.Api.Models.Dtos.Recipes;

namespace CookiFind.Api.Services.Interfaces.Recipes;

public interface IRecipeCategoryService
{
    Task<List<RecipeCategoryDto>> GetAllAsync();
}
