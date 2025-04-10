using CookiFind.Api.Models.Domain.Recipes;
using Microsoft.EntityFrameworkCore;

namespace CookiFind.Api.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(CookiFindDbContext context)
    {
        await context.Database.MigrateAsync();

        await SeedRecipeCategoriesAsync(context);
    }

    private static async Task SeedRecipeCategoriesAsync(CookiFindDbContext context)
    {
        if (!context.RecipeCategories.Any())
        {
            var categories = new List<RecipeCategory>
            {
                new RecipeCategory
                {
                    Id = Guid.Parse("fd0758a6-a1ed-4d05-afdc-d6e4189c7f21"),
                    Name = "Appetizers",
                    CookidooId = "VrkNavCategory-RPF-001",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("03d7257b-cee0-4256-8e43-aac489787fc8"),
                    Name = "Soups",
                    CookidooId = "VrkNavCategory-RPF-002",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("dacbb358-6082-4a10-a210-9a459077f0d5"),
                    Name = "Pasta & Rice Dishes",
                    CookidooId = "VrkNavCategory-RPF-003",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("fb487a86-7f4b-4536-954b-b5616e8dd821"),
                    Name = "Main dishes – Meat",
                    CookidooId = "VrkNavCategory-RPF-004",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("de6b17c6-463a-49e6-9dc1-f0dc42507c6d"),
                    Name = "Main dishes – Fish",
                    CookidooId = "VrkNavCategory-RPF-005",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("12942154-0672-4e48-9789-ed5daf656a0f"),
                    Name = "Main dishes – Vegetarian",
                    CookidooId = "VrkNavCategory-RPF-006",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("f8eff110-05ee-4b94-96f3-55d934e4521a"),
                    Name = "Main dishes – Other",
                    CookidooId = "VrkNavCategory-RPF-007",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("5c818977-76b8-4014-a513-26a64d207d06"),
                    Name = "Side Dishes",
                    CookidooId = "VrkNavCategory-RPF-008",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("39de8ea0-b0d8-4c66-8516-e1c55ee6a6bb"),
                    Name = "Sauces, Dips and Spreads – Sweet",
                    CookidooId = "VrkNavCategory-RPF-009",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("66b44fe0-2a7a-448c-a75f-0882754030d9"),
                    Name = "Desserts and Sweets",
                    CookidooId = "VrkNavCategory-RPF-011",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("4e6c95d6-849e-4e0e-8a37-c93af32ed540"),
                    Name = "Baking – Savory",
                    CookidooId = "VrkNavCategory-RPF-012",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("f7278ad5-3d3c-4912-b42d-92487e1fbbe9"),
                    Name = "Baking – Sweet",
                    CookidooId = "VrkNavCategory-RPF-013",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("21b494af-71fd-4da8-a42c-921e94453b95"),
                    Name = "Breads and Rolls",
                    CookidooId = "VrkNavCategory-RPF-014",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("8a3e3682-a69c-4f58-bcca-94ff48de8b5f"),
                    Name = "Drinks",
                    CookidooId = "VrkNavCategory-RPF-015",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("c93a8d27-d348-4eae-a989-067aca6fc869"),
                    Name = "Basics",
                    CookidooId = "VrkNavCategory-RPF-016",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("b4761e36-4e96-43ae-802e-53595420a52b"),
                    Name = "Baby food",
                    CookidooId = "VrkNavCategory-RPF-017",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("73dd6368-5c3f-4840-aa67-7ecb4bb5aaa9"),
                    Name = "Sauces, Dips and Spreads – Savory",
                    CookidooId = "VrkNavCategory-RPF-018",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("91957ae5-bf50-4d48-9839-d284ea778c26"),
                    Name = "Breakfast",
                    CookidooId = "VrkNavCategory-RPF-019",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("af15b6fc-03d1-4c90-bc86-37bb1fdd1ed8"),
                    Name = "Snacks",
                    CookidooId = "VrkNavCategory-RPF-020",
                },
                new RecipeCategory
                {
                    Id = Guid.Parse("2c6e2238-4fb0-4eb7-913f-7571351e1a7f"),
                    Name = "Menus and More",
                    CookidooId = "VrkNavigationCategory-rpf-000001303095",
                }
            };

            context.RecipeCategories.AddRange(categories);
            await context.SaveChangesAsync();
        }
    }
}
