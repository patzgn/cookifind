namespace CookiFind.Application.Services.Interfaces.Scrapers;

public interface IScraper
{
    Task<bool> ScrapeAndSaveRecipesAsync(CancellationToken cancellationToken);
    Task<bool> ScrapeAndSaveRecipesAsync(Guid recipeCategoryId, CancellationToken cancellationToken);
}
