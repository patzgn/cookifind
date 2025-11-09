using CookiFind.Application.Database;
using CookiFind.Application.Models.Recipes;
using CookiFind.Application.Repositories.Interfaces.Recipes;
using Microsoft.EntityFrameworkCore;

namespace CookiFind.Application.Repositories.Recipes;

public class RecipeCategoryRepository(CookiFindDbContext dbContext) : IRecipeCategoryRepository
{
    public async Task<IEnumerable<RecipeCategory>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.RecipeCategories
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<RecipeCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.RecipeCategories
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }
}
