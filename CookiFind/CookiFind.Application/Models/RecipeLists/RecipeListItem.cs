namespace CookiFind.Application.Models.RecipeLists;

public class RecipeListItem
{
    public Guid Id { get; set; }

    public Guid RecipeListId { get; set; }

    public Guid RecipeId { get; set; }
}
