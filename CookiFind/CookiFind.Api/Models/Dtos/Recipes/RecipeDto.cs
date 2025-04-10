namespace CookiFind.Api.Models.Dtos.Recipes;

public class RecipeDto
{
    public required string CookidooId { get; set; }

    public required string Name { get; set; }

    public required double CaloriesInKcal { get; set; }

    public required double ProteinInGrams { get; set; }

    public required double CarbohydratesInGrams { get; set; }

    public required double FatInGrams { get; set; }
}
