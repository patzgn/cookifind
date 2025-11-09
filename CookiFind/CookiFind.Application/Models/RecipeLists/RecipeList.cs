namespace CookiFind.Application.Models.RecipeLists;

public class RecipeList
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string UserId { get; set; }

    
}
