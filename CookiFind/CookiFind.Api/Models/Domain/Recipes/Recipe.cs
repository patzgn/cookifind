namespace CookiFind.Api.Models.Domain.Recipes;

public class Recipe
{
    public Guid Id { get; set; }

    public required string CookidooId { get; set; }

    public required string Name { get; set; }

    public required Guid CategoryId { get; set; }
    public RecipeCategory Category { get; set; } = null!;

    public required RecipeNutritionInfo NutritionInfo { get; set; }
}
