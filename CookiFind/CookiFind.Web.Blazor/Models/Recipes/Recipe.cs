namespace CookiFind.Web.Blazor.Models.Recipes;

public class Recipe
{
    public required string Name { get; init; }
    
    public required string CategoryName { get; init; }

    public required double Calories { get; init; }

    public required double Proteins { get; init; }

    public required double Carbohydrates { get; init; }

    public required double Fats { get; init; }

    public required string CookidooPath { get; init; }
}
