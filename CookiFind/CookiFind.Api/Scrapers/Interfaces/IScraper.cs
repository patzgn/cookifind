using CookiFind.Api.Models.Domain.Recipes;

namespace CookiFind.Api.Scrapers.Interfaces;

public interface IScraper
{
    Task ScrapeAndSaveRecipesAsync();
    Task ScrapeAndSaveRecipesAsync(RecipeCategory category);
}
