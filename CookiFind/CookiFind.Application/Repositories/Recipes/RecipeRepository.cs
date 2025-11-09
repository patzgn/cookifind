using CookiFind.Application.Database;
using CookiFind.Application.Models.Recipes;
using CookiFind.Application.Repositories.Interfaces.Recipes;
using Dapper;

namespace CookiFind.Application.Repositories.Recipes;

public class RecipeRepository(IDbConnectionFactory dbConnectionFactory) : IRecipeRepository
{
    public async Task<bool> CreateAsync(Recipe recipe, CancellationToken cancellationToken = default)
    {
        return true;
        // using var connection = await _dbConnectionFactory.CreateConnectionAsync(cancellationToken);
        //
        // var result = await connection.ExecuteAsync(new CommandDefinition(
        //     """
        //     insert into recipes (id, slug, title, yearofrelease)
        //     values (@Id, @CookidooId, @Name, @CategoryId, @RecipeNutritionInfoId)
        //     """, recipe, cancellationToken: cancellationToken));
        //
        // return result > 0;
    }

    public async Task<bool> CreateAsync(IEnumerable<Recipe> recipes, CancellationToken cancellationToken = default)
    {
        using var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);
        using var transaction = connection.BeginTransaction();

        var nutritionResult = await connection.ExecuteAsync(new CommandDefinition(
            """
            insert into recipe_nutrition_infos (id, calories_in_kcal, proteins_in_grams, carbohydrates_in_grams, fats_in_grams)
            values (@Id, @CaloriesInKcal, @ProteinInGrams, @CarbohydratesInGrams, @FatInGrams);
            """, recipes.Select(x => x.NutritionInfo), cancellationToken: cancellationToken));

        var recipeResult = await connection.ExecuteAsync(new CommandDefinition(
            """
            insert into recipes (id, cookidoo_id, name, category_id, nutrition_info_id)
            values (@Id, @CookidooId, @Name, @CategoryId, @NutritionInfoId);
            """, recipes, cancellationToken: cancellationToken));

        transaction.Commit();

        return nutritionResult == recipeResult 
               && recipeResult > 0;
    }

    public async Task<IEnumerable<string>> GetCookidooIdsAsync(Guid categoryId,
        CancellationToken cancellationToken = default)
    {
        using var connection = await dbConnectionFactory.CreateConnectionAsync(cancellationToken);

        return await connection.QueryAsync<string>(new CommandDefinition(
            """
            select r.cookidoo_id
            from recipes r
            where r.category_id = @CategoryId
            """, new { categoryId }, cancellationToken: cancellationToken));
    }
}
