using CookiFind.Api.Data;
using CookiFind.Api.Models.Domain.Recipes;
using CookiFind.Api.Repositories.Interfaces.Recipes;
using Microsoft.EntityFrameworkCore;

namespace CookiFind.Api.Repositories.Recipes;

public class RecipeCategoryRepository(CookiFindDbContext context) : IRecipeCategoryRepository
{
    public async Task<List<RecipeCategory>> GetAllAsync()
    {
        return await context.RecipeCategories
            .AsNoTracking()
            .ToListAsync();
    }
}
