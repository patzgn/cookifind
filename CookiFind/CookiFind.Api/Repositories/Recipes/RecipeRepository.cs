using CookiFind.Api.Data;
using CookiFind.Api.Models.Domain.Recipes;
using CookiFind.Api.Repositories.Interfaces.Recipes;
using Microsoft.EntityFrameworkCore;

namespace CookiFind.Api.Repositories.Recipes;

public class RecipeRepository(CookiFindDbContext context) : IRecipeRepository
{
    public async Task AddAsync(Recipe recipe)
    {
        await context.Recipes.AddAsync(recipe);
        await context.SaveChangesAsync();
    }

    public async Task AddAsync(IEnumerable<Recipe> recipes)
    {
        context.ChangeTracker.AutoDetectChangesEnabled = false;

        try
        {
            await context.Recipes.AddRangeAsync(recipes);
            await context.SaveChangesAsync();
        }
        finally
        {
            context.ChangeTracker.AutoDetectChangesEnabled = true;
        }
    }

    public async Task<IEnumerable<string>> GetCookidooIdsAsync(Guid categoryId)
    {
        return await context.Recipes
            .Where(x => x.CategoryId == categoryId)
            .Select(x => x.CookidooId)
            .ToListAsync();
    }
}
