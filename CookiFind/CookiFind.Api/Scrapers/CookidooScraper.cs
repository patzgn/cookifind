using CookiFind.Api.Models.Domain.Recipes;
using CookiFind.Api.Repositories.Interfaces.Recipes;
using CookiFind.Api.Scrapers.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CookiFind.Api.Scrapers;

public class CookidooScraper(
    IRecipeCategoryRepository recipeCategoryRepository,
    IRecipeRepository recipeRepository,
    IRecipeScraper recipeScraper,
    ILogger<CookidooScraper> logger)
    : IScraper
{
    public async Task ScrapeAndSaveRecipesAsync()
    {
        var categories = await recipeCategoryRepository.GetAllAsync();
        foreach (var category in categories)
        {
            await ScrapeAndSaveRecipesAsync(category);
        }
    }

    public async Task ScrapeAndSaveRecipesAsync(RecipeCategory category)
    {
        try
        {
            logger.LogInformation("Scraping recipes for category: {CategoryName} ({CategoryId})", category.Name,
                category.CookidooId);

            var recipeIds = await GetRecipesIdsAsync(category.CookidooId);
            var existingRecipeIds = await recipeRepository.GetCookidooIdsAsync(category.Id);

            var missingRecipeIds = recipeIds.Except(existingRecipeIds).ToArray();
            if (missingRecipeIds.Length == 0)
            {
                logger.LogInformation("No new recipes found for category: {CategoryName}", category.Name);
                return;
            }

            var tasks = missingRecipeIds.Select(async recipeId =>
            {
                try
                {
                    return await recipeScraper.GetRecipeAsync(recipeId, category.Id);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error scraping recipe {RecipeId} for category {CategoryName}", recipeId,
                        category.Name);
                    return null;
                }
            });

            var recipes = await Task.WhenAll(tasks);

            var validRecipes = recipes.OfType<Recipe>().ToList();
            if (validRecipes.Count > 0)
            {
                await recipeRepository.AddAsync(validRecipes);
                logger.LogInformation("Added {RecipeCount} new recipes to category {CategoryName}", validRecipes.Count,
                    category.Name);
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error scraping category {CategoryName}", category.Name);
        }
    }


    #region Scrape recipes ID
    
    private async Task<IEnumerable<string>> GetRecipesIdsAsync(string categoryId)
    {
        var url = BuildUrl(categoryId);
    
        using var driver = ConfigureWebDriver();
        try
        {
            await driver.Navigate().GoToUrlAsync(url);
    
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    
            return CollectRecipes(driver, wait);
        }
        finally
        {
            driver.Quit();
        }
    }
    
    private string BuildUrl(string? categoryId) =>
        $"https://cookidoo.pl/search/pl?countries=pl&context=recipes&sortby=publishedAt&accessories=includingBladeCoverWithPeeler,includingCutter&categories={categoryId}";
    
    private IWebDriver ConfigureWebDriver()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--headless");
        chromeOptions.AddArgument("--disable-gpu");
        chromeOptions.AddArgument("--window-size=1920,1080");
    
        var driver = new ChromeDriver(chromeOptions);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    
        return driver;
    }
    
    private HashSet<string> CollectRecipes(IWebDriver driver, WebDriverWait wait)
    {
        var recipeIds = new HashSet<string>();
        var endOfPageReached = false;
    
        while (!endOfPageReached)
        {
            var recipes = driver.FindElements(By.TagName("core-tile"));
            foreach (var recipe in recipes)
            {
                var id = recipe.GetDomAttribute("id");
                if (!string.IsNullOrEmpty(id))
                {
                    recipeIds.Add(id);
                }
            }
    
            endOfPageReached = !ClickLoadMoreButton(wait);
        }
    
        return recipeIds;
    }
    
    private bool ClickLoadMoreButton(WebDriverWait wait)
    {
        try
        {
            var loadMoreButton = wait.Until(driver =>
                {
                    try
                    {
                        return driver.FindElement(By.CssSelector("[data-cy='load-more-button']"));
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }
                }
            );
    
            loadMoreButton?.Click();
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("The ‘Load More’ button was not found. End of page.");
            return false;
        }
    }
    
    #endregion
}
