namespace CookiFind.Api.Models.Domain.Recipes;

public class RecipeCategory
{
    public Guid Id { get; set; }

    public required string CookidooId { get; set; }

    public required string Name { get; set; }

    public List<Recipe> Recipes { get; set; } = [];
}
