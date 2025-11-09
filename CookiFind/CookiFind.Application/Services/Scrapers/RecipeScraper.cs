using System.Text.RegularExpressions;
using AngleSharp;
using AngleSharp.Dom;
using CookiFind.Application.Models.Recipes;
using CookiFind.Application.Services.Interfaces.Scrapers;
using Microsoft.Extensions.Logging;
using Microsoft.Playwright;

namespace CookiFind.Application.Services.Scrapers;

public class RecipeScraper(ILogger<RecipeScraper> logger, HttpClient httpClient) : IRecipeScraper
{
    private static readonly Regex NumericRegex = new(@"([0-9]+\.?[0-9]*)", RegexOptions.Compiled);

    private const string BaseRecipeUrl = "https://cookidoo.thermomix.com/recipes/recipe/en-US/";

    public async Task<IEnumerable<string>> GetRecipesIdsAsync(string categoryId)
    {
        var url = BuildUrl(categoryId);
        var recipeIds = new HashSet<string>();

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
        var page = await browser.NewPageAsync();
        await page.GotoAsync(url);

        while (true)
        {
            var newIds = await page.EvaluateAsync<string[]>(
                "Array.from(document.querySelectorAll('core-tile[id]')).map(tile => tile.id);");

            if (newIds.Length == 0 || !recipeIds.Union(newIds).Any())
                break;

            recipeIds.UnionWith(newIds);

            var loadMore = await page.QuerySelectorAsync("[data-cy='load-more-button']");
            if (loadMore == null)
                break;

            await loadMore.ClickAsync();
            await page.WaitForTimeoutAsync(1000);
        }

        return recipeIds;
    }

    // public async Task<IEnumerable<string>> GetRecipesIdsAsync(string categoryId)
    // {
    //     var recipeIds = new HashSet<string>();
    //     var page = 0;
    //     var hasMorePages = true;
    //
    //     while (hasMorePages)
    //     {
    //         var url = BuildUrl(categoryId, page);
    //         var document = await LoadHtmlDocumentAsync(url);
    //         if (document is null)
    //         {
    //             logger.LogWarning("Failed to load document for category ID: {CategoryId} and page: {Page}", categoryId,
    //                 page);
    //             page++;
    //             continue;
    //         }
    //
    //         var newIds = CollectRecipes(document);
    //
    //         if (newIds.Count == 0)
    //             hasMorePages = false;
    //         else
    //         {
    //             recipeIds.UnionWith(newIds);
    //             page++;
    //         }
    //     }
    //
    //     return recipeIds;
    // }

    public async Task<Recipe?> GetRecipeAsync(string recipeId, Guid categoryId)
    {
        try
        {
            var url = $"{BaseRecipeUrl}{recipeId}";

            var document = await LoadHtmlDocumentAsync(url);
            if (document is null)
            {
                logger.LogWarning("Failed to load document for recipe ID: {RecipeId}", recipeId);
                return null;
            }

            var recipeName = ExtractName(document);
            var nutrients = ExtractNutrients(document);

            return BuildRecipe(recipeId, categoryId, recipeName, nutrients);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while fetching recipe {RecipeId}", recipeId);
            return null;
        }
    }

    private string BuildUrl(string categoryId) =>
        $"https://cookidoo.pl/search/pl?countries=pl&context=recipes&sortby=publishedAt&accessories=includingBladeCoverWithPeeler,includingCutter&categories={categoryId}";

    private HashSet<string> CollectRecipes(IDocument document)
    {
        var recipeIds = new HashSet<string>();

        var recipeElements = document.QuerySelectorAll("core-tile[id]");
        foreach (var element in recipeElements)
        {
            var id = element.Id;
            if (!string.IsNullOrEmpty(id))
            {
                recipeIds.Add(id);
            }
        }

        return recipeIds;
    }

    private async Task<IDocument?> LoadHtmlDocumentAsync(string url)
    {
        try
        {
            logger.LogInformation("Fetching recipe from {Url}", url);

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.9");
            request.Headers.Add("Referer", "https://cookidoo.pl/");

            var response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogWarning("Failed to fetch {Url}, status code: {StatusCode}", url, response.StatusCode);
                return null;
            }

            var html = await response.Content.ReadAsStringAsync();

            var configuration = Configuration.Default.WithDefaultLoader();
            var browsingContext = BrowsingContext.New(configuration);

            return await browsingContext.OpenAsync(req => req.Content(html));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error loading HTML for {RecipeId}", url);
            return null;
        }
    }

    private string ExtractName(IDocument document)
    {
        var titleNode = document.QuerySelector("h1.recipe-card__title");
        return titleNode?.TextContent.Trim() ?? "Unknown title";
    }

    private Dictionary<string, double> ExtractNutrients(IDocument document)
    {
        var nutrients = new Dictionary<string, double>();
        var nutrientElements = document.QuerySelectorAll(".nutritions dt, .nutritions dd");

        if (nutrientElements.Length % 2 != 0)
        {
            logger.LogWarning("Mismatched nutrient elements count in document.");
            return nutrients;
        }

        for (var i = 0; i < nutrientElements.Length; i += 2)
        {
            var name = nutrientElements[i]?.TextContent.Trim();
            var valueText = nutrientElements[i + 1]?.TextContent.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(valueText))
            {
                continue;
            }

            valueText = valueText.Split('/').LastOrDefault()?.Trim() ?? string.Empty;

            var match = NumericRegex.Match(valueText);
            if (match.Success && double.TryParse(match.Groups[1].Value, out var numericValue))
            {
                nutrients[name] = numericValue;
            }
        }

        return nutrients;
    }

    private Recipe BuildRecipe(string recipeId, Guid categoryId, string recipeName,
        Dictionary<string, double> nutrients)
    {
        var recipeNutritionInfo = new RecipeNutritionInfo
        {
            Id = Guid.NewGuid(),
            CaloriesInKcal = nutrients.GetValueOrDefault("Calories", 0),
            CarbohydratesInGrams = nutrients.GetValueOrDefault("Carbohydrates", 0),
            FatInGrams = nutrients.GetValueOrDefault("Fat", 0),
            ProteinInGrams = nutrients.GetValueOrDefault("Protein", 0),
        };

        return new Recipe
        {
            Id = Guid.NewGuid(),
            Name = recipeName,
            CategoryId = categoryId,
            CookidooId = recipeId,
            NutritionInfoId = recipeNutritionInfo.Id,
            NutritionInfo = recipeNutritionInfo,
        };
    }
}
