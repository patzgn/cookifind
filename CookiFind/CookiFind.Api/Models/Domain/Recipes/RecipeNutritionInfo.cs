namespace CookiFind.Api.Models.Domain.Recipes;

public class RecipeNutritionInfo
{
    public Guid Id { get; set; }

    public required double CaloriesInKcal { get; set; }

    public required double ProteinInGrams { get; set; }

    public required double CarbohydratesInGrams { get; set; }

    public required double FatInGrams { get; set; }
}
