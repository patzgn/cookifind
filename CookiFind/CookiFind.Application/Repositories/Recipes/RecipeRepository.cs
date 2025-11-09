using CookiFind.Application.Database;
using CookiFind.Application.Models.Recipes;
using CookiFind.Application.Repositories.Interfaces.Recipes;
using Microsoft.EntityFrameworkCore;

namespace CookiFind.Application.Repositories.Recipes;

public class RecipeRepository(CookiFindDbContext dbContext) : IRecipeRepository
{
    public async Task<bool> CreateAsync(Recipe recipe, CancellationToken cancellationToken = default)
    {
        await dbContext.AddAsync(recipe, cancellationToken);
        var result = await dbContext.SaveChangesAsync(cancellationToken);

        return result > 0;
    }

    public async Task<bool> CreateAsync(IEnumerable<Recipe> recipes, CancellationToken cancellationToken = default)
    {
        await dbContext.AddRangeAsync(recipes, cancellationToken);
        var result = await dbContext.SaveChangesAsync(cancellationToken);

        return result > 0;
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        var recipe = await dbContext.Recipes
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

        return recipe is not null;
    }

    public async Task<IEnumerable<string>> GetCookidooIdsAsync(Guid categoryId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Recipes
            .AsNoTracking()
            .Where(x => x.CategoryId == categoryId)
            .Select(x => x.CookidooId)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
