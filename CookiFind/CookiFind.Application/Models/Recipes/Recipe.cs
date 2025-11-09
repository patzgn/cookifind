namespace CookiFind.Application.Models.Recipes;

public class Recipe
{
    public Guid Id { get; init; }

    public required string CookidooId { get; init; }

    public required string Name { get; set; }

    public required Guid CategoryId { get; set; }
    public RecipeCategory Category { get; set; } = null!;

    public required Guid NutritionInfoId { get; set; }
    public RecipeNutritionInfo NutritionInfo { get; set; } = null!;
}
