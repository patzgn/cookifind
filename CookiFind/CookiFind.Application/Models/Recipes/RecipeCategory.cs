namespace CookiFind.Application.Models.Recipes;

public class RecipeCategory
{
    public required Guid Id { get; init; }

    public required string CookidooId { get; set; }

    public required string Name { get; set; }
}
