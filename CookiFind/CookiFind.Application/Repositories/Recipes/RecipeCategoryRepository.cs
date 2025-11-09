using CookiFind.Application.Database;
using CookiFind.Application.Models.Recipes;
using CookiFind.Application.Repositories.Interfaces.Recipes;
using Dapper;

namespace CookiFind.Application.Repositories.Recipes;

public class RecipeCategoryRepository(IDbConnectionFactory dbConnectionFactory) : IRecipeCategoryRepository
{
    public async Task<IEnumerable<RecipeCategory>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        using var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);

        return await connection.QueryAsync<RecipeCategory>(new CommandDefinition(
            """
            select rc.*
            from recipe_categories rc
            """, cancellationToken: cancellationToken));
    }

    public async Task<RecipeCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        using var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);
        
        return await connection.QuerySingleOrDefaultAsync<RecipeCategory>(new CommandDefinition(
            """
            select rc.*
            from recipe_categories rc
            where rc.id = @id
            """, new { id }, cancellationToken: cancellationToken));
    }
}
