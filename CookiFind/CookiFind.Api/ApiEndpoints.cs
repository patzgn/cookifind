namespace CookiFind.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class RecipeCategories
    {
        private const string Base = $"{ApiBase}/recipe-categories";

        public const string GetAll = Base;
    }
    
    public static class Recipes
    {
        private const string Base = $"{ApiBase}/recipes";
        
        public const string Scrape = $"{Base}/scrape";
    }

    public static class Ratings
    {
        private const string Base = $"{ApiBase}/ratings";

        public const string GetUserRatings = $"{Base}/me";
    }
}
