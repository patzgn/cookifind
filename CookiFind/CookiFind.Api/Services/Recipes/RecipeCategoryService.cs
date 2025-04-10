using CookiFind.Api.Models.Dtos.Recipes;
using CookiFind.Api.Repositories.Interfaces.Recipes;
using CookiFind.Api.Services.Interfaces.Recipes;

namespace CookiFind.Api.Services.Recipes;

public class RecipeCategoryService(IRecipeCategoryRepository repository) : IRecipeCategoryService
{
    public async Task<List<RecipeCategoryDto>> GetAllAsync()
    {
        var categories = await repository.GetAllAsync();

        var categoryDtos = categories.Select(
            x => new RecipeCategoryDto
            {
                Name = x.Name,
            }).ToList();

        return categoryDtos;
    }
}
